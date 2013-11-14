using Service.Contracts;
using Service.SharedSession;

namespace Service
{
    [SharedInstance]
    public class SharedInstanceStatefulService : IStatefulService
    {
        private int _counter;

        public SharedInstanceStatefulService()
        {
            _counter = 0;
        }

        public int IncrementAndReturn()
        {
            return ++_counter;
        }
    }

    public class StatefulService: IStatefulService
    {
       private int _counter;

       public StatefulService()
        {
            _counter = 0;
        }

        public int IncrementAndReturn()
        {
            return ++_counter;
        }
    }
}