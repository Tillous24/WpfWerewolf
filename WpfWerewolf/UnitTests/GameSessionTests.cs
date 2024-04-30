using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Werewolf_Companion.Domain_Model;

namespace WpfWerewolf.UnitTests
{
    [TestClass]
    public class GameSessionTests
    {
        private GameSession _gameSession;

        [TestInitialize]
        public void Setup()
        {
            _gameSession = new GameSession();
        }

        [TestMethod]
        public void TestAddPlayer()
        {
            // Arrange
            Player player = new Player("John");

            // Act
            _gameSession.AddPlayer(player);

            // Assert
            CollectionAssert.Contains(_gameSession.ActiveParticipants(), player);
        }

        [TestMethod]
        public void TestRemovePlayer()
        {
            // Arrange
            Player player = new Player("John");
            _gameSession.AddPlayer(player);

            // Act
            _gameSession.RemovePlayer(player);

            // Assert
            CollectionAssert.DoesNotContain(_gameSession.ActiveParticipants(), player);
        }

        [TestMethod]
        public void TestNumParticipants()
        {
            // Arrange
            _gameSession.AddPlayer(new Player("John"));
            _gameSession.AddPlayer(new Player("Alice"));

            // Act & Assert
            Assert.AreEqual(2, _gameSession.NumParticipants());
        }

        [TestMethod]
        public void TestAddRole()
        {
            // Arrange
            Role role = new Werewolf();

            // Act
            _gameSession.AddRole(role);

            // Assert
            List<Role> selectedRoles = _gameSession.SelectedRoles();
            if (selectedRoles.Contains(role))
            {
                Console.WriteLine("AddRole Test Passed");
            }
            else
            {
                Console.WriteLine("AddRole Test Failed");
            }
        }
    }
}
