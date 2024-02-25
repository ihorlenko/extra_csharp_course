using System;
using SCG = System.Collections.Generic;

using State = System.Int32;
using Input = System.Char;

namespace MyRegEx
{
    class DFA
    {
        public State start;
        public HashSet<State> final;
        public SCG.SortedList<KeyValuePair<State, Input>, State> transitionFunction;

        public DFA()
        {
            final = new HashSet<State>();
            transitionFunction = new SCG.SortedList<KeyValuePair<State, Input>, State>(new Comparer());
        }

        public bool Recognize(string @input)
        {
            State state = start;

            CharEnumerator i = @input.GetEnumerator();

            while (i.MoveNext())
            {
                KeyValuePair<State, Input> transition = new KeyValuePair<State, Input>(state, i.Current);

                if (!transitionFunction.ContainsKey(transition))
                    return false;

                state = transitionFunction[transition];
            }

            if (final.Contains(state))
                return true;
            else
                return false;
        }

        public void AddTransition(State source, string @symbols, State target)
        {
            CharEnumerator i = @symbols.GetEnumerator();

            while (i.MoveNext())
            {
                this.transitionFunction.Add(new KeyValuePair<State, Input>(source, i.Current), target);
            }
        }
    }

    public class Comparer : SCG.IComparer<KeyValuePair<State, Input>>
    {
        public int Compare(KeyValuePair<State, Input> transition1, KeyValuePair<State, Input> transition2)
        {
            if (transition1.Key == transition2.Key)
                return transition1.Value.CompareTo(transition2.Value);
            else
                return transition1.Key.CompareTo(transition2.Key);
        }
    }

}

