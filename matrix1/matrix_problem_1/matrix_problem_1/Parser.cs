using System;


namespace MyRegEx
{
	public struct Parser
	{
        private static FloatRecognizer floatRecognizer = new FloatRecognizer();
        private static ExponentRecognizer expRecognizer = new ExponentRecognizer();

        public Parser() { }

        public static List<Tuple<string, string>> parse(string @description)
        {
            List<Tuple<string, string>> parameters = new List<Tuple<string, string>>();
            CharEnumerator i = @description.GetEnumerator();
            string alpha = "", beta = "", exp_expression = "";
            int position = 0;

            if (description == "0")
            {
                return new List<Tuple<string, string>> { new Tuple<string, string>("0.0", "0.0") };
            }

            while (i.MoveNext())
            {
                if ("*(".Contains(i.Current))
                {
                    if (i.Current == '(') { exp_expression += i.Current; }
                    if (position > 1 && i.Current == '*') { exp_expression += i.Current; }
                    position += 1;
                    continue;
                }
                else if (i.Current == ')')
                {
                    exp_expression += i.Current;
                    if (!floatRecognizer.Recognize(alpha)) { alpha = "100.0"; }
                    if (!floatRecognizer.Recognize(beta)) { beta = "100.0"; }
                    else if (!expRecognizer.Recognize(exp_expression)) { beta = "100.0"; }
                    parameters.Add(new Tuple<string, string>(alpha, beta));
                    alpha = ""; beta = ""; exp_expression = "";
                    position = 0;
                    continue;
                }

                if (position < 1) { alpha += i.Current; }
                if (position >= 1) { exp_expression += i.Current; }
                if (position == 2) { beta += i.Current; }
            }

            return parameters;
        }
    }
}

