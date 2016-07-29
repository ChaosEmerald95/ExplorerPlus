using System;

namespace ExplorerPlus.API
{
    public static class ExtraFunctions
    {
        public static string UnitChange(double bytesize)
        {
            double Size = bytesize;

            //Byte zu Kilobyte (durch 1024)
            if (Size < 1024)
            {
                return Size.ToString() + " B";
                //Weniger als 1 KB
            }
            else {
                Size /= 1024;
            }

            //Kilobyte zu Megabyte (durch 1024)
            if (Size < 1024)
            {
                if (Size < 10)
                {
                    return Math.Round(Size, 2).ToString() + " KB";
                }
                else if (Size < 100)
                {
                    return Math.Round(Size, 1).ToString() + " KB";
                }
                else {
                    return Math.Round(Size, 0).ToString() + " KB";
                }
            }
            else {
                Size /= 1024;
            }

            //Megabyte zu Gigabyte (durch 1024)
            if (Size < 1024)
            {
                if (Size < 10)
                {
                    return Math.Round(Size, 2).ToString() + " MB";
                }
                else if (Size < 100)
                {
                    return Math.Round(Size, 1).ToString() + " MB";
                }
                else {
                    return Math.Round(Size, 0).ToString() + " MB";
                }
            }
            else {
                Size /= 1024;
            }

            //Gigabyte zu Terabyte
            if (Size < 1024)
            {
                if (Size < 10)
                {
                    return Math.Round(Size, 2).ToString() + " GB";
                }
                else if (Size < 100)
                {
                    return Math.Round(Size, 1).ToString() + " GB";
                }
                else {
                    return Math.Round(Size, 0).ToString() + " GB";
                }
            }
            else {
                Size /= 1024;
            }

            //Terabyte zu Petabyte
            if (Size < 1024)
            {
                if (Size < 10)
                {
                    return Math.Round(Size, 2).ToString() + " TB";
                }
                else if (Size < 100)
                {
                    return Math.Round(Size, 1).ToString() + " TB";
                }
                else {
                    return Math.Round(Size, 0).ToString() + " TB";
                }
            }
            else {
                Size /= 1024;
            }

            //Petabyte zu Exabyte
            if (Size < 1024)
            {
                if (Size < 10)
                {
                    return Math.Round(Size, 2).ToString() + " PB";
                }
                else if (Size < 100)
                {
                    return Math.Round(Size, 1).ToString() + " PB";
                }
                else {
                    return Math.Round(Size, 0).ToString() + " PB";
                }
            }
            else {
                Size /= 1024;
            }

            //Exabyte zu Zettabyte
            if (Size < 1024)
            {
                if (Size < 10)
                {
                    return Math.Round(Size, 2).ToString() + " EB";
                }
                else if (Size < 100)
                {
                    return Math.Round(Size, 1).ToString() + " EB";
                }
                else {
                    return Math.Round(Size, 0).ToString() + " EB";
                }
            }
            else {
                Size /= 1024;
            }

            //Zettabyte zu Yottabyte
            if (Size < 1024)
            {
                if (Size < 10)
                {
                    return Math.Round(Size, 2).ToString() + " ZB";
                }
                else if (Size < 100)
                {
                    return Math.Round(Size, 1).ToString() + " ZB";
                }
                else {
                    return Math.Round(Size, 0).ToString() + " ZB";
                }
            }
            else {
                Size /= 1024;
                if (Size < 10)
                {
                    return Math.Round(Size, 2).ToString() + " YB";
                    //Höchste Einheit
                }
                else if (Size < 100)
                {
                    return Math.Round(Size, 1).ToString() + " YB";
                    //Höchste Einheit
                }
                else {
                    return Math.Round(Size, 0).ToString() + " YB";
                    //Höchste Einheit
                }
            }
        }

        public static string GetFileSizeKB(double filesize)
        {
            double size = Math.Round(filesize / 1024, 0);
            string text = GetNumberWithPoints(size) + " KB";
            return text;
        }

        public static string GetNumberWithPoints(double number)
        {
            string t = "";
            string text = number.ToString().Reverse(); ;
            int pointc = Convert.ToInt32(Math.Floor(Convert.ToDecimal(text.Length / 3))) + 1;
            if (text.Length % 3 == 0)
                pointc--;
            if (pointc > 0 && text.Length > 2)
            {
                for (int i = 0; i < pointc; i++)
                {
                    if (t == "")
                        t = text.Substring(i * 3, 3);
                    else
                        if (text.Length - (i * 3) < 3)
                        t += "." + text.Substring(i * 3, text.Length - (i * 3));
                    else

                        t += "." + text.Substring(i * 3, 3);
                }
                text = t.Reverse();
            }
            else
            {
                text = text.Reverse();
            }
            return text;
        }

        private static string Reverse(this string s)
        {
            char[] c = s.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }

        /// <summary>
        /// Gibt einen Text als gekürzte Variante aus
        /// </summary>
        /// <param name="text">Der Text, der gekürzt werden soll</param>
        /// <param name="maxlength">Die maximale Länge des Textes</param>
        /// <param name="fromend">Wenn auf true, dann wird vom Anfang der Text mit ... abgekürzt. Wenn auf false, dann wird am Ende des Textes mit ... abgekürzt</param>
        /// <returns></returns>
        public static string ShortText(string text, int maxlength, bool fromend = false)
        {
            if (text.Length < maxlength) return text; //Wenn der Text noch im Rahmen ist

            if (fromend)
            {
                return "..." + text.Substring(text.Length - maxlength, maxlength);
            }
            else
            {
                return text.Substring(0, maxlength) + "...";
            }
        }

        public static string TimeConverter(int seconds)
        {
            int minutes, hours;
            if (seconds < 60)
            {
                if (seconds == 1)
                    return "1 Sekunde";
                else
                    return seconds.ToString() + " Sekunden";
            }

            minutes = (int)Math.Floor((double)seconds / 60);
            if (minutes < 60)
            {
                string msga;
                if (minutes == 1)
                    msga = "1 Minute";
                else
                    msga = minutes.ToString() + " Minuten";

                if (seconds - (minutes * 60) == 1)
                    msga += " 1 Sekunde";
                else if (seconds - (minutes * 60) > 1)
                    msga += " " + seconds.ToString() + " Sekunden";

                return msga;
            }

            hours = (int)Math.Floor((double)minutes / 60);
            string msg;
            if (hours == 1)
                msg = "1 Stunde";
            else
                msg = hours.ToString() + " Stunden";

            if (minutes - (hours * 60) == 1)
                msg += " 1 Minute";
            else if (minutes - (hours * 60) > 1)
                msg +=  " " + minutes.ToString() + " Sekunden";

            if (seconds - (minutes * 60) == 1)
                msg += " 1 Sekunde";
            else if (seconds - (minutes * 60) > 1)
                msg += " " + seconds.ToString() + " Sekunden";

            return msg;
        }
    }
}
