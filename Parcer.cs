namespace ROOT86
{
    public class ParsedCommand
    {
        public string Path { get; set; } = "";

        public string Operator { get; set; } = "";

        public string Payload { get; set; } = "";
    }

    public static class Parser
    {
        public static ParsedCommand? Parse(string input)
        {
            string[] operators =
            {
                ".==",
                ".//",
                ".=",
                ".?"
            };

            foreach (string op in operators)
            {
                int index = input.IndexOf(op);

                if (index != -1)
                {
                    return new ParsedCommand
                    {
                        Path = input.Substring(0, index),

                        Operator = op,

                        Payload = input.Substring(
                            index + op.Length
                        )
                    };
                }
            }

            return null;
        }
    }
}
