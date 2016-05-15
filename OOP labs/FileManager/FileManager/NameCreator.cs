namespace FileManager
{
    class NameCreator
    {
        public static string GetName(string[] parts, int minLength)
        {
            string entityName = "";

            if (parts.Length > minLength)
            {
                for (int i = minLength - 1; i < parts.Length; ++i)
                {
                    entityName += parts[i] + " ";
                }

                entityName = entityName.TrimEnd(' ');
            }
            else
            {
                entityName = parts[minLength - 1];
            }

            return entityName;
        }
    }
}
