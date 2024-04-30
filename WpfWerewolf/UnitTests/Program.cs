using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWerewolf.UnitTests
{
    class Program
    {
        static void TestRunns()
        {
            GameSessionTests gameSessionTests = new GameSessionTests();
            gameSessionTests.TestAddPlayer();
            gameSessionTests.TestRemovePlayer();
            gameSessionTests.TestAddRole();
        }
    }
}
