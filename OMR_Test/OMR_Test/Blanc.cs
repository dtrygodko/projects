using System;

namespace OMR_Test
{
    struct Blanc
    {
        public string Name { get; }
        public string LastName { get; }
        public string Group { get; }
        public DateTime Date { get; }
        public double Result { get; }
        public string Subject { get; }

        public Blanc(string name, string lastName, string group, string subject, double result)
        {
            Name = name;
            LastName = lastName;
            Group = group;
            Result = result;
            Subject = subject;
            Date = DateTime.Now;
        }
    }
}
