using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Subsystem
{
	public class Curl
	{
		// https://stackoverflow.com/questions/7929013/making-a-curl-call-in-c-sharp/56678505#56678505
		protected static string ExecuteCurl(string curlCommand, int timeoutInSeconds = 15)
		{
			if (string.IsNullOrEmpty(curlCommand))
				return "";

			curlCommand = curlCommand.Trim();

			// remove the curl keworkd
			if (curlCommand.StartsWith("curl"))
			{
				curlCommand = curlCommand.Substring("curl".Length).Trim();
			}

			curlCommand = curlCommand.Replace("--compressed", "");

			// windows 10 should contain this file
			var fullPath = "curl.exe";

			if (System.IO.File.Exists(fullPath) == false)
			{
				throw new Exception("curl.exe missing");
			}

			// on windows ' are not supported. For example: curl 'http://ublux.com' does not work and it needs to be replaced to curl "http://ublux.com"
			List<string> parameters = new List<string>();

			// separate parameters to escape quotes
			try
			{
				Queue<char> q = new Queue<char>();

				foreach (var c in curlCommand.ToCharArray())
				{
					q.Enqueue(c);
				}

				StringBuilder currentParameter = new StringBuilder();

				void insertParameter()
				{
					var temp = currentParameter.ToString().Trim();
					if (string.IsNullOrEmpty(temp) == false)
					{
						parameters.Add(temp);
					}

					currentParameter.Remove(0, currentParameter.Length);
				}

				while (true)
				{
					if (q.Count == 0)
					{
						insertParameter();
						break;
					}

					char x = q.Dequeue();

					if (x == '\'')
					{
						insertParameter();

						// add until we find last '
						while (true)
						{
							x = q.Dequeue();

							// if next 2 characetrs are \' 
							if (x == '\\' && q.Count > 0 && q.Peek() == '\'')
							{
								currentParameter.Append('\'');
								q.Dequeue();
								continue;
							}

							if (x == '\'')
							{
								insertParameter();
								break;
							}

							currentParameter.Append(x);
						}
					}
					else if (x == '"')
					{
						insertParameter();

						// add until we find last "
						while (true)
						{
							x = q.Dequeue();

							// if next 2 characetrs are \"
							if (x == '\\' && q.Count > 0 && q.Peek() == '"')
							{
								currentParameter.Append('"');
								q.Dequeue();
								continue;
							}

							if (x == '"')
							{
								insertParameter();
								break;
							}

							currentParameter.Append(x);
						}
					}
					else
					{
						currentParameter.Append(x);
					}
				}
			}
			catch
			{
				throw new Exception("Invalid curl command");
			}

			StringBuilder finalCommand = new StringBuilder();

			foreach (var p in parameters)
			{
				if (p.StartsWith("-"))
				{
					finalCommand.Append(p);
					finalCommand.Append(" ");
					continue;
				}

				var temp = p;

				if (temp.Contains("\""))
				{
					temp = temp.Replace("\"", "\\\"");
				}
				if (temp.Contains("'"))
				{
					temp = temp.Replace("'", "\\'");
				}

				finalCommand.Append($"\"{temp}\"");
				finalCommand.Append(" ");
			}

			Console.WriteLine(finalCommand);

			using (Process process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = "curl.exe",
					Arguments = finalCommand.ToString(),
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = false,
					CreateNoWindow = true
				}
			})
			{
				process.Start();
				StringBuilder stringBuilder = new StringBuilder();
				StreamReader read = process.StandardOutput;
				while (read.Peek() >= 0)
					stringBuilder.AppendLine(read.ReadLine());
				process.WaitForExit(timeoutInSeconds * 1000);

				Console.WriteLine(stringBuilder.ToString());

				return stringBuilder.ToString();
			}
		}

		public static string DownloadWebPage(string url)
		{
			return ExecuteCurl(string.Format("curl '{0}'", url));
		}
	}
}
