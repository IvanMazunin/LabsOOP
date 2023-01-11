namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMoneyArrayConstructorRandom()
        {
            MoneyArray banks = new MoneyArray(10, 1, 15);
            Assert.IsNotNull(banks);
        }
        [TestMethod]
        public void TestCollectionMoneyConstructor()
        {
            MoneyArray banks = new MoneyArray();
            Assert.IsNotNull(banks);
        }
        [TestMethod]
        public void TestCollectionMoneyToString()
        {
            MoneyArray banks = new MoneyArray();
            string result = banks.ToString();
            Assert.AreEqual(result, "{ 0.00; }");
        }
        [TestMethod]
        public void TestMoneyArrayIndex()
        {
            MoneyArray banks = new MoneyArray();
            MoneyArray moneyArray = new MoneyArray();
            Money testBank = new Money();
            Money oneBank = new Money(6, 95);
            moneyArray[0] = oneBank;
            testBank = banks[0];
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => testBank = banks[2]);
            Assert.AreEqual(moneyArray[0], oneBank);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => moneyArray[2] = oneBank);
        }
        [TestMethod]
        public void TestMoneyArrayGetBanks()
        {
            MoneyArray banks = new MoneyArray();
            MoneyArray copyBanks = new MoneyArray();
            copyBanks.getBanks = banks.getBanks;
            Assert.AreEqual(banks.getBanks, copyBanks.getBanks);
        }
        [TestMethod]
        public void TestProgramFindMinBank()
        {
            Money bank = new Money(0, 0);
            MoneyArray banks = new MoneyArray(10, 1, 50);
            banks[5] = bank;
            Assert.AreEqual(Program.FindMinBank(banks), bank);

        }
        [TestMethod]
        public void TestMainMenuConstructor()
        {
            MainMenu menu = new MainMenu();
            Assert.IsNotNull(menu);
        }
        [TestMethod]
        public void TestBankCopyConstructor()
        {
            Money bank = new Money(5, 99);
            Money copyBank = new Money(bank);
            Assert.AreEqual(copyBank.Rub, bank.Rub);
            Assert.AreEqual(copyBank.Kop, bank.Kop);
        }
        [TestMethod]
        public void TestBankSetNums()
        {
            Money expectedMoney = new Money(5, 99);
            Money editMoney = new Money();
            editMoney.Rub = 5;
            editMoney.Kop = 99;
            Assert.AreEqual(editMoney.Rub, expectedMoney.Rub);
            Assert.AreEqual(editMoney.Kop, expectedMoney.Kop);
            expectedMoney = new Money(-1, 100);
            editMoney.Rub = -1;
            editMoney.Kop = 100;
            Assert.AreEqual(editMoney.Rub, -1);
            Assert.AreEqual(editMoney.Kop, 100);
        }
        [TestMethod]
        public void TestMoneyGetCount()
        {
            Money bank = new Money();
            int testCounter = Money.count;
        }
        [TestMethod]
        public void TestMoneyUnaryOperations()
        {
            Money bank = new Money(5, 99);
            ++bank;
            Assert.AreEqual(bank.Rub, 6);
            Assert.AreEqual(bank.Kop, 0);
            --bank;
            Assert.AreEqual(bank.Rub, 5);
            Assert.AreEqual(bank.Kop, 99);
        }
        [TestMethod]
        public void TestMoneyBinaryOperations()
        {
            Money bank = new Money(5, 55);
            Money result = bank + 10;
            Assert.AreEqual(result.Rub, 5);
            Assert.AreEqual(result.Kop, 65);
            result = 10 + bank;
            Assert.AreEqual(result.Rub, 5);
            Assert.AreEqual(result.Kop, 75);
            result = 10 - bank;
            Assert.AreEqual(result.Rub, 5);
            Assert.AreEqual(result.Kop, 75);
            result = bank - 10;
            Assert.AreEqual(result.Rub, 5);
            Assert.AreEqual(result.Kop, 65);
            result = 565 - bank;
            Assert.AreEqual(result.Rub, 0);
            Assert.AreEqual(result.Kop, 0);
        }
        [TestMethod]
        public void TestPointCastOperations()
        {
            Money bank = new Money(5, 55);
            int rub = (int)bank;
            Assert.AreEqual(5, rub);
            double kop = bank;
            Assert.AreEqual(0.55, kop);
        }
    }
}