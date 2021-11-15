using System.Collections;
using System.Collections.Generic;

namespace RepositoryExercise
{
    public class RepositoryTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Album(0, "ddd", "cvzc", 1989, "Pop", 30232, true, "ceva") };
            yield return new object[] { new Album(0, "vewsw", "kjbfs", 1989, "Pop", 30232, false, "ceva") };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

