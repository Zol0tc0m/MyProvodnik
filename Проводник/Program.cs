using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using Проводник;

class Programa
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            DriveInfo[] drivesinfo = DriveInfo.GetDrives();
            foreach (DriveInfo driveinfo in drivesinfo)
            {
                Console.WriteLine($"      Имя диска: {driveinfo.Name}  Всего места на диске: {driveinfo.TotalSize / (1024 * 1024 * 1024)}  Доступно места: {driveinfo.AvailableFreeSpace / (1024 * 1024 * 1024)} ГБ");
            }
            int select = Strelki.Show(0, 1);
            if (select == 0)
            {
                ShowPapka(drivesinfo[select].Name);
            }
            else if (select == -1)
            {
                Main();
            }
        }
        void ShowPapka(string s)
        {
            while (true)
            {
                Console.Clear();
                string[] paths = Directory.GetDirectories(s);
                string[] pathsFiles = Directory.GetFiles(s);

                foreach (string path in paths)
                {
                    Console.WriteLine("  " + path);
                }
                foreach (string pathFiles in pathsFiles)
                {
                    DirectoryInfo Files = new DirectoryInfo(pathFiles);
                    Console.WriteLine($"      {pathFiles}  {Files.CreationTime}  {Files.Extension}");
                }
                //выводятся файлы
                int posission = Strelki.Show(0, paths.Length + pathsFiles.Length - 1);
                if (posission == -1)
                {
                    return;
                }
                if (posission < paths.Length)
                {
                    ShowPapka(paths[posission]);
                }
                else
                {
                    Process.Start(new ProcessStartInfo { FileName = pathsFiles[posission - paths.Length], UseShellExecute = true });
                    Console.WriteLine("Запустилось");
                }
            }
        }
    }
}