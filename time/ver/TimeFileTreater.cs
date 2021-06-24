using System;
using System.Text;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace time
{
    public struct Lex
    {
        public bool negation;
        public string lexem;

        public Lex(string lex)
        {
            negation = false;
            lexem = lex;
        }
        public Lex(string lex, bool neg)
        {
            negation = neg;
            lexem = lex;
        }

        /// <summary>
        /// Проверяет выполняемость лексемы для строки.
        /// </summary>
        /// <param name="str">Проверяемая строка</param>
        /// <returns>Возвращает истину, если лексема выполнена для строки</returns>
        public bool check(String str)
        {
            bool result;
            if (!empty())
                if (!negation) result = str.Contains(lexem);
                else result = !str.Contains(lexem);
            else result = true;
            
            return result;
        }

        public bool empty()
        {
            return lexem.Length == 0;
        }

        public override string ToString()
        {
            return (!empty()?(negation?"not ":"")+"contains '"+lexem+"'" : "");
        }

    }//Lex

    public class LexAnd
    {
        public Lex lex1;
        public Lex lex2;
        public LexAnd()
        {
            lex1 = new Lex("");
            lex2 = new Lex("");
        }
        public LexAnd(Lex l1, Lex l2)
        {
            lex1 = l1;
            lex2 = l2;
        }

        public bool empty()
        {
            return (lex1.lexem.Length == 0 && lex2.lexem.Length == 0);
        }

        /// <summary>
        /// Проверяет выполняемость лексемы для строки.
        /// </summary>
        /// <param name="str">Проверяемая строка</param>
        /// <returns>Возвращает истину, если лексема выполнена для строки</returns>
        public bool check(String str)
        {
            bool result;
            
            if (!empty())
                result = lex1.check(str) && lex2.check(str);
            else
                result = false;
            
            return result;
        }

        public override string ToString()
        {
            return (!empty() ? lex1.ToString() + ( (!lex1.empty() && !lex2.empty()) ? " and " : "") + lex2.ToString() : "");
        }
    }//LexAnd

    class TimeFileTreater
    {
        enum State { Symbol, Time };
        public static int buffSize = 1024*8;
        public int timeLength = 14;
        Encoding enc = Encoding.GetEncoding(1251); // объект для декодирования данных 
        public static string dtFormatString = @"MM/dd HH:mm:ss";
        DateTimeFormatInfo dtFormatInfo = new DateTimeFormatInfo();
        //public delegate void PercentHandler(object sender, int percent);
        //public event PercentHandler PercentChanged;
        public string resultMessage = "";
        private bool _result=true;
        public bool Result
        {
            get { return _result; }
        }

        public TimeFileTreater()
        {
            dtFormatInfo.DateSeparator = "/";
        }

        /// <summary>
        /// Возвращает строку формата даты-времени из начала строки. 
        /// </summary>
        /// <remarks>
        /// В файле просматриваются первые 15 строк, выделяется дата-время из начала строки и применяется 
        /// попытка преобразовать текст в dataTime по всем шаблонам из .Settings.Default.dtFormats
        /// Если попытка была успешной, то возвращается строка формата. Если ни один шаблон 
        /// </remarks>
        /// <param name="sourceFile">файл</param>
        /// <returns>строку формата даты-времени</returns>
        public string GetDateTimeFormatString(string sourceFile)
        {
            const string datetimeExpr = @"^(\d*[-:/.,Tt ]?([pa]m)?)*";
            Match mt;

            string dtFormat = string.Empty;
            DateTime dt;
            DateTimeFormatInfo dtFormatInfo = new DateTimeFormatInfo();

            int cnt = 0; bool success = false;

            if (File.Exists(sourceFile))
                foreach (string str in File.ReadLines(sourceFile))
                {
                    cnt++;
                    mt = Regex.Match(str, datetimeExpr);
                    if (mt.Success)
                    {
                        foreach (string dtF in time.Properties.Settings.Default.dtFormats)
                            if (DateTime.TryParseExact(mt.Value, dtF, dtFormatInfo, DateTimeStyles.AllowTrailingWhite, out dt))
                            {
                                dtFormat = dtF;
                                success = true;
                                break;
                            }
                    }
                    if (success || cnt == 15) break;
                }
            
            return dtFormat;
        }

        /// <summary>
        /// Сдвиг времени
        /// </summary>
        /// <param name="sourceFile">Источник</param>
        /// <param name="resultFile">Результат</param>
        /// <param name="deltaTime">Сдвиг</param>
        /// <param name="sign">Направление сдвига</param>
        /// <returns></returns>
        public bool RedefineTime(string sourceFile, string resultFile, TimeSpan deltaTime, int sign)
        {
            byte[] buff = new byte[buffSize]; //буфер данных
            byte[] dtArr = new byte[timeLength - 1]; //пересчитанное время, переведенное в байты для прямого копирования в буфер
            byte[] buffRemain = new byte[timeLength]; //остаток буфера
            bool result = true; //результат обработки
            string curDtString, dtString; //буфер для времени в строковом формате 
            int numOfByte; //количество байтов в буфере для обработки
            int readedByte; //количество считанных из файла байт
            int i, k; //индекс для обращения к буферу 
            State st; //состояние автомата
            Boolean isBuffTreated; //признак, что вся порция данных в буфере обработана
            DateTime newDt; //буфер для пересчета времени
            FileStream sourceFstream, destFstream; // потоки для исходных и результирующих данных

            //int sz = enc.GetByteCount();

            resultMessage = "";
            _result = true;
            if (File.Exists(sourceFile))
            {
                sourceFstream = File.OpenRead(sourceFile);
                if (Directory.Exists(Path.GetDirectoryName(resultFile)))
                {
                    try
                    {
                        destFstream = File.Create(resultFile);
                        curDtString = "-";
                        i = 0; numOfByte = 0;
                        st = State.Time;
                        
                        do
                        {
                            if (i > 0) buffRemain.CopyTo(buff, 0); // копируем остаток буфера с предыдущей итерации в начало
                            readedByte = sourceFstream.Read(buff, i, buff.Length - i); // заполняем оставшуюся часть буфера символами из файла
                            if (readedByte > 0)
                            {
                                numOfByte = readedByte + i; //имеем для обработки количество считанных символов плюс остаток буфера
                                i = 0; isBuffTreated = false;
                                //debug
                                //debugs = enc.GetString(buff);
                                while (!isBuffTreated)
                                {
                                    if (st == State.Symbol)
                                    {
                                        while (i < numOfByte && buff[i] != 10) i++; //найдем перенос на новую строку

                                        if (i < numOfByte) // нашли перенос. Предполагаем, что строка начинается с времени
                                        {
                                            st = State.Time;
                                            i++;
                                        }
                                        else // не нашли
                                        {
                                            isBuffTreated = true;
                                            i = 0;
                                        }
                                    }

                                    else // st==State.Time
                                    {
                                        if (i + timeLength < numOfByte) //хватает остатка буфера для определения времени
                                        {
                                            dtString = enc.GetString(buff, i, timeLength);
                                            if (dtString == curDtString) // время не изменилось 
                                            {
                                                dtArr.CopyTo(buff, i);
                                                i += timeLength;
                                                st = State.Symbol;
                                            }
                                            else // время изменилось. Пересчитаем.
                                                if (DateTime.TryParseExact(dtString, dtFormatString, dtFormatInfo, DateTimeStyles.None, out newDt))
                                                {
                                                    curDtString = newDt.ToString(dtFormatString, dtFormatInfo);
                                                    // пересчет времени
                                                    if (sign > 0)
                                                        newDt = newDt.Add(deltaTime);
                                                    else
                                                        newDt = newDt.Subtract(deltaTime);

                                                    dtArr = enc.GetBytes(newDt.ToString(dtFormatString, dtFormatInfo));
                                                    dtArr.CopyTo(buff, i);
                                                    i += timeLength;
                                                    st = State.Symbol;
                                                }
                                                else // оказалось, начало строки - не время.
                                                {
                                                    st = State.Symbol;
                                                }

                                            //sw.WriteLine(dtString);

                                        }
                                        else // (i+timeSize >= numOfByte)
                                        // не хватает остатка буфера для времени. 
                                        // необходимо загрузить новую порцию данных в буфер
                                        {
                                            // скопируем остаток буфера
                                            isBuffTreated = true;
                                            k = 0;
                                            while (i < numOfByte)
                                            {
                                                buffRemain[k++] = buff[i++];
                                            }
                                            i = k;
                                        }
                                    }//if state...

                                }//while(isBuffTreated)
                                
                                destFstream.Write(buff, 0, numOfByte - i);

                            }//readedByte>0

                        } while (readedByte > 0);

                        if (i > 0) //необработанный остаток
                            destFstream.Write(buff, 0, i);
                        
                        sourceFstream.Close();
                        destFstream.Close();
                        resultMessage = "ok.";
                    }
                    catch (Exception e)
                    {
                        result = false;
                        resultMessage = "An error occurred while processing: " + e.Message;
                    }

                } //Directory.Exists(Path.GetDirectoryName(resultFile))
                else
                {
                    result = false;
                    resultMessage = "Incorrect path for the output file.";
                }
            } // File.Exists(sourceFile)
            else { result = false; resultMessage = "File not found."; }

            _result = result;
            return result;
        }
        /*
         * старая версия
        public bool RemoveString(string sourceFile, string resultFile, Lex l)
        {
            bool result = true; //результат обработки
            StreamReader fSrc;
            StreamWriter fOut;
            string line;
            try
            {
                using (fSrc = new StreamReader(sourceFile, enc))
                {
                    using (fOut = new StreamWriter(resultFile, false, enc))
                    {
                        while ((line = fSrc.ReadLine()) != null)
                        {
                            if (checkLexem(line,l)) fOut.WriteLine(line);
                        }

                        fOut.Close();
                    } //using fOut
                    result = true;
                    resultMessage = "ok.";
                    fSrc.Close();
               } //using fSrc
            }
            catch (Exception e)
            {
                result = false;
                resultMessage = "An error occurred while processing: " + e.Message;
            }
            return result;
        }
        
        public bool RemoveString(string sourceFile, string resultFile, Lex l1, Lex l2)
        {
            bool result = true; //результат обработки
            if (l2.lexem.Length>0)
            {
                StreamReader fSrc;
                StreamWriter fOut;
                string line;

                try
                {
                    using (fSrc = new StreamReader(sourceFile, enc))
                    {
                        using (fOut = new StreamWriter(resultFile, false, enc))
                        {
                            while ((line = fSrc.ReadLine()) != null)
                            {
                                if (checkLexem(line, l1))
                                    fOut.WriteLine(line);

                                else
                                {
                                    if (checkLexem(line, l2))
                                        fOut.WriteLine(line);
                                }
                            }

                            fOut.Close();
                        } //using fOut
                        result = true;
                        resultMessage = "ok.";
                        fSrc.Close();
                    } //using fSrc
                }
                catch (Exception e)
                {
                    result = false;
                    resultMessage = "An error occurred while processing: " + e.Message;
                }
            }
            else //(l2.lexem.Length==0)
                result = RemoveString(sourceFile, resultFile, l1);
            return result;
        }
        
        private bool checkLexem(string line, Lex l)
        {
            bool result;
            result = !line.Contains(l.lexem);
            if (l.negation) result = !result;
            return result;
        }
        */
        /// <summary>
        /// Удаляет строки согласно фильтру
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="resultFile"></param>
        /// <param name="lexList"></param>
        /// <returns></returns>
        public bool RemoveString(string sourceFile, string resultFile, List<LexAnd> lexList)
        {
            bool result = true; //результат обработки
            if (lexList.Count > 0)
            {
                StreamReader fSrc;
                StreamWriter fOut;
                string line;
                int lexNum, removed=0;
                int[] lexCnt = new int[lexList.Count];


                try
                {
                    using (fSrc = new StreamReader(sourceFile, enc))
                    {
                        using (fOut = new StreamWriter(resultFile, false, enc))
                        {
                            // удаляем строки
                            while ((line = fSrc.ReadLine()) != null)
                            {
                                lexNum = checkLexem(line, lexList);
                                if (lexNum < 0)
                                    fOut.WriteLine(line);
                                else
                                {
                                    removed++;
                                    lexCnt[lexNum]++;
                                }
                            }

                            if (removed > 0)
                            {
                                fOut.WriteLine("===========================================");
                                fOut.WriteLine("Were removed "+removed.ToString()+" string(s) including:");
                                fOut.WriteLine("-------------------------------------------");
                                for (int i = 0; i < lexList.Count; i++)
                                    if (lexCnt[i] > 0)
                                    {
                                        fOut.WriteLine('-'+lexCnt[i].ToString()+" string(s) "+lexList[i].ToString());
                                    }
                                fOut.WriteLine("===========================================");
                            }
                            
                            fOut.Close();
                        } //using fOut
                        result = true;
                        resultMessage = "ok.";
                        fSrc.Close();
                    } //using fSrc
                }
                catch (Exception e)
                {
                    result = false;
                    resultMessage = "An error occurred while processing: " + e.Message;
                }
            }
            else //(l2.lexem.Length==0)
            {
                result = false;
                resultMessage = "Does not specified the conditions.";
            }
            _result = result;
            return result;
        }

        /// <summary>
        /// Проверяет строку на выполнимость условия списка лексем
        /// Возвращает номер первой из списка лексемы, которая содержится в строке. Если ни одной лексемы не обнаружено, возвращается -1
        /// </summary>
        /// <param name="s">проверяемая строка</param>
        /// <param name="lexList">список лексем</param>
        /// <returns>Номер лексемы</returns>
        private int checkLexem(string s, List<LexAnd> lexList)
        {
            int result = -1;

            for (int i=0; i<lexList.Count; i++) 
            {
                if (lexList[i].check(s)) { result = i;  break; }
            }
            
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="resultFile"></param>
        /// <param name="dtBeg"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        public bool RemoveString(string sourceFile, string resultFile, DateTime dtBeg, DateTime dtEnd)
        {
            bool result = true; //результат обработки
            bool inPer; //признак, что последняя дата удовлетворяет периоду
            bool header;
            bool hasBeg = (dtBeg != DateTime.MinValue);
            bool hasEnd = (dtEnd != DateTime.MaxValue);
            StreamReader fSrc;
            StreamWriter fOut;
            string line;
            DateTime dt;

            resultMessage = "Remove line "+"\r\n";
            dtFormatString = GetDateTimeFormatString(sourceFile);
            if (dtFormatString != string.Empty)
                
                try
                {
                    using (fSrc = new StreamReader(sourceFile, enc))
                    {
                        using (fOut = new StreamWriter(resultFile, false, enc))
                        {
                            // удаляем строки
                            inPer = false; header = true;
                            while ((line = fSrc.ReadLine()) != null)
                            {
                                if (line.Length >= dtFormatString.Length
                                    && DateTime.TryParseExact(line.Substring(0, dtFormatString.Length), dtFormatString, dtFormatInfo, DateTimeStyles.None, out dt)
                                )
                                {
                                    header = false;
                                    if (!inPer)
                                    {
                                        if (!hasBeg || dt >= dtBeg)
                                        {
                                            if (!hasEnd || dt <= dtEnd) { inPer = true; fOut.WriteLine(line); }
                                            else break;
                                        }
                                    }
                                    else
                                        if (!hasEnd || dt <= dtEnd) fOut.WriteLine(line);
                                        else break;

                                }
                                else // строка начинается не с даты
                                    if (inPer||header) fOut.WriteLine(line);
                                   
                            }

                            fOut.Close();
                        } //using fOut
                        result = true;
                        resultMessage = "ok.";
                        fSrc.Close();
                    } //using fSrc
                }
                catch (Exception e)
                {
                    result = false;
                    resultMessage = "An error occurred while processing: " + e.Message;
                }

            else
            {
                if (File.Exists(sourceFile))
                    resultMessage = "Unknown datetime format.";
                else resultMessage = "File does not exist.";
                result = false;
            }
            _result = result;
            return result;

        }
        
        public string OutOpen(string File)
        {
            string result="";
            if (File.Length > 0)
            {
                ProcessStartInfo pInfo = new ProcessStartInfo();
                pInfo.FileName = File;
                pInfo.UseShellExecute = true;
                try
                {
                    Process.Start(pInfo);
                }
                catch (FileNotFoundException e) { result = "File is not found " + e.FileName; }
                catch (Exception e) { result = "Error running file " + e.Message; }
                
            }
            else
                result = "File is not specified";

            return result;
        }

        /*
        public void Translate()
        {
            // Строка для разбора
            //         const string input = "(1+2)<=(3/45)";
            const string input = "2+3*4";
            //         const string input = "(D_1 >= 0.34) && (D2 <7.5) + A*568 || xyz";

            // Получаем массив строк с отдельными элементами выражения
            Regex rx = new Regex(@"\(|\)|\+|\-|\*|\/|<=?|>=?|!=|=|&&|\|\||([a-zA-z][a-zA-z0-9_]*)|(\d+\.?\d*)");
            // разбиваем на токены
            MatchCollection mc = rx.Matches(input);

            Regex id = new Regex(@"[a-zA-z][a-zA-z0-9_]*"); // идентификаторы
            Regex num = new Regex(@"\d+\.?\d*"); // числа целые и дробные
            Regex skobki = new Regex(@"\(|\)"); // скобки
            string[] operators = { "(", ")", "*", "/", "+", "-", "<", ">", "<=", ">=", "==", "!=", "&&", "||" }; // операторы по приоритету
            // [url]www.cyberguru.ru/programming/cpp/cpp-programming-guide-page35.html[/url]
            Regex opers = new Regex(@"\(|\)|\+|\-|\*|\/|<=?|>=?|!=|=|&&|\|\|"); // операторы

            Stack stOper = new Stack();
            ArrayList expr = new ArrayList();
            foreach (Match m in mc)
            {
                Match m1;
                m1 = id.Match(m.Value);
                if (m1.Success) { expr.Add(m1.Value); continue; }
                m1 = num.Match(m.Value);
                if (m1.Success) { expr.Add(m1.Value); continue; }
                m1 = skobki.Match(m.Value);
                if (m1.Success)
                {
                    if (m1.Value == "(") { stOper.Push(m1.Value); continue; }
                    string op = stOper.Pop().ToString();
                    while (op != "(")
                    {
                        expr.Add(op);
                        op = stOper.Pop().ToString();
                    }
                    continue;
                }
                m1 = opers.Match(m.Value);
                if (m1.Success)
                {
                    try
                    {
                        while (Array.IndexOf(operators, m1.Value) > Array.IndexOf(operators, stOper.Peek()))
                        {
                            if (stOper.Peek().ToString() == "(") break;
                            expr.Add(stOper.Pop().ToString());
                        }
                    }
                    catch (System.Exception ex)
                    {
                        // стек пустой
                    }
                    stOper.Push(m1.Value);
                }
            }
            while (stOper.Count != 0)
            {
                expr.Add(stOper.Pop().ToString());
            }

            // Выводим результат
            string res="";
            foreach (string s in expr)
            {
                res = res + s + " ";
            }
            res = res + " ";
        }//translate
        */

        //public void Translate1()

        /*
         public static void CreateTest(string resultFile, int size)
         {
             int curSize = 0;
             string line;
             CultureInfo ci=new CultureInfo("en-US");
             string[] suffics = { 
                                    @"D main player DPA-ASB8: cuePlay 1.000 5036 0", 
                                    @"D main player DPA-ASB7: waitForTdCued, time 20 mS", 
                                    @"D main player DPA-ASB7: detach /fs/clip.dir/СЖT ID карта (кирилов)22_162386.mxf S_auto 0x10a1e548 0/2 0 5037", 
                                    @"D main player DPA-ASB7: setMaxPos 6735->7633 @5049 09/12 16:37:21 D Host2  player DEC_8B_PVW: setMaxPos  0->22125 @0", 
                                    @"D Host2  player DEC_8B_PVW: setPos 0 0x00000000" 
                                };
             Random rnd = new Random();
            
             using (StreamWriter sw = File.CreateText(resultFile))
             {
                 while (curSize<size)
                 {
                     line=String.Format("{0} {1}", DateTime.Now.ToString(dtFormatString, ci),suffics[rnd.Next(5)]);
                     sw.WriteLine(line);
                     curSize += (line.Length+2);
                 }
             }

         }
         */

    }
}
