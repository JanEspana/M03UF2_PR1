namespace M03_UF2_PR1_ClassLibrary
{
    public class PR1Library
    {
        public static bool InRange(int num, int max, int min)
        {
            return num >= min && num <= max;
        }
        public static bool NameCheck(string names)
        {
            int commaCount = 0;
            char comma = ',';
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == comma)
                {
                    commaCount++;
                }
            }
            if (commaCount >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
