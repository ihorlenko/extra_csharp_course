using System;

namespace MyRegEx
{
	public class ExponentRecognizer
	{
        private DFA dfa;

        public ExponentRecognizer()
		{
			this.dfa = new DFA();
            this.dfa.AddTransition(0, "e", 1);
            this.dfa.AddTransition(1, "x", 2);
            this.dfa.AddTransition(2, "p", 3);
            this.dfa.AddTransition(3, "(", 4);

            this.dfa.AddTransition(4, "+-", 5);
            this.dfa.AddTransition(4, "123456789", 6);
            this.dfa.AddTransition(4, "0", 7);
            this.dfa.AddTransition(5, "0", 7);
            this.dfa.AddTransition(5, "123456789", 6);
            this.dfa.AddTransition(6, "0123456789", 6);
            this.dfa.AddTransition(6, ".", 8);
            this.dfa.AddTransition(7, ".", 8);
            this.dfa.AddTransition(8, "0123456789", 9);
            this.dfa.AddTransition(9, "0123456789", 9);

            this.dfa.AddTransition(6, "*", 10);
            this.dfa.AddTransition(7, "*", 10);
            this.dfa.AddTransition(9, "*", 10);

            this.dfa.AddTransition(10, "t", 11);
            this.dfa.AddTransition(11, ")", 12);

            this.dfa.final.Add(12);
        }

        public bool Recognize(string input)
        {
            return dfa.Recognize(input);
        }
    }
}

