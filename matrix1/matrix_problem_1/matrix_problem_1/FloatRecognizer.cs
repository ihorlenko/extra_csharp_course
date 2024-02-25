using System;


namespace MyRegEx
{
	public struct FloatRecognizer
	{
        private DFA dfa;

		public FloatRecognizer()
		{
            this.dfa = new DFA();
            this.dfa.AddTransition(0, "+-", 1);
            this.dfa.AddTransition(0, "123456789", 2);
            this.dfa.AddTransition(0, "0", 3);
            this.dfa.AddTransition(1, "0", 3);
            this.dfa.AddTransition(1, "123456789", 2);
            this.dfa.AddTransition(2, "0123456789", 2);
            this.dfa.AddTransition(2, ".", 4);
            this.dfa.AddTransition(3, ".", 4);
            this.dfa.AddTransition(4, "0123456789", 5);
            this.dfa.AddTransition(5, "0123456789", 5);
            this.dfa.final.Add(2);
            this.dfa.final.Add(3);
            this.dfa.final.Add(5);
        }

        public bool Recognize(string input)
        {
            return dfa.Recognize(input);
        }
	}
}

