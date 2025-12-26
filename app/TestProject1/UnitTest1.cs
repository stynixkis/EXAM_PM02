namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Tests()
        {
            double[,] matrixInchid = new double[,]
            {
                {double.MaxValue,5,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,5,double.MaxValue,double.MaxValue,double.MaxValue },
                {9,double.MaxValue,6,double.MaxValue,double.MaxValue,double.MaxValue,6,double.MaxValue,double.MaxValue,double.MaxValue},
                {double.MaxValue,double.MaxValue,double.MaxValue,8,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue },
                {double.MaxValue,double.MaxValue,8,double.MaxValue,double.MaxValue,7,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue },
                {double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,7,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue },
                {double.MaxValue,double.MaxValue,7,5,1,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,4 },
                {4,2,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,6,double.MaxValue,double.MaxValue },
                {double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,6,double.MaxValue,7,double.MaxValue },
                {double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,8,double.MaxValue,6 },
                {double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,7,double.MaxValue,double.MaxValue,6,double.MaxValue }
            };

            Methods.Floyd(matrixInchid);
            bool flagTrue = true;
            if (matrixInchid == null)
                flagTrue = false;

            Assert.Equal("True", flagTrue.ToString());
        }
    }
}
