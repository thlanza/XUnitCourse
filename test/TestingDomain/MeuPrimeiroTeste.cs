using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestingDomain
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "Testar2")]
        public void DeveVariavel1SerIgualVariavel2()
        {
            ///AAA
            //Arrange
            var variavel = 1;
            var variavel2 = 1;

            //Act

            //Assert
            Assert.Equal(variavel, variavel2);
        }
    }
}
