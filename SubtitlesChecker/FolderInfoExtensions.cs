using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmonic.Subtitles
{
	public static class FolderInfoExtensions
	{
		/// <summary>
		/// Проверяет существование и доступность путей и файла дефолтных субтитров
		/// </summary>
		/// <param name="folderInfo">проверяемый FolderInfo</param>
		/// <param name="defaultSubtitles">файл дефолтных субтитров</param>
		/// <param name="message">сообщение об ошибке</param>
		/// <returns></returns>
		public static bool ValidateFolder(this FolderInfo folderInfo, out String message)
		{
			string msg;

			if (!Network.IsPathAvailable(folderInfo.SourceFolder, out msg))
			{
				message = $"{msg} {folderInfo.SourceFolder}";
				return false;
			}

			if (!Network.IsPathAvailable(folderInfo.TargetFolder, out msg))
			{
				message = $"{msg} {folderInfo.TargetFolder}";
				return false;
			}

			message = null;
			return true;
		}

		public async static Task<String> ValidateFolderAsync(this FolderInfo folderInfo)
		{
			string message;

			message = await Task.Run(() => 
				Network.IsPathAvailable(folderInfo.SourceFolder)
			);
			if (message!=null)
			{
				return $"{message} {folderInfo.SourceFolder}";
			}

			message = await Task.Run(() =>
				Network.IsPathAvailable(folderInfo.TargetFolder)
			);
			if (message != null)
			{
				return $"{message} {folderInfo.TargetFolder}";
			}

			return null;
		}

	}
}
