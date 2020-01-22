using System;
using Xunit;
using ExpectedObjects;
using TestingDomain._Util;
using Xunit.Abstractions;
using TestingDomain._Builders;
using Bogus;
using Cursos.Domain.Cursos;


namespace TestingDomain.Cursos
{
    
    public class CursoTeste : IDisposable
    {
        //"Eu, enquanto administrador, quero criar e editar cursos para que sejam abertas matrículas para o mesmo."

        //Critérios de aceite

        //-Criar um curso com nome, carga horária, público alvo e valor do curso.
        //-As opções para público alvo são: Estudante, Universitário, Empregado e Empreendedor.
        //-Todos os campos do curso são obrigatórios.
        //-Curso deve ter uma descrição.


        private readonly string _nome;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;
        private readonly ITestOutputHelper _output;
        private readonly string _descricao;

        public CursoTeste(ITestOutputHelper output)
        {
            _output = output;
            var faker = new Faker();
            _nome = faker.Random.Word();
            _cargaHoraria = faker.Random.Double(50, 1000);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = faker.Random.Double(100, 1000);
            _descricao = faker.Lorem.Paragraph();

            
            _output = output;
            _output.WriteLine($"Double: {faker.Random.Double()}");
            _output.WriteLine($"Double: {faker.Company.CompanyName()}");
            _output.WriteLine($"Double: {faker.Person.Email}");
        }


        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950,
                Descricao = _descricao
            };

    

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
       

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComNome(nomeInvalido).Build())
                .ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            
   
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build())
                .ComMensagem("Carga horária inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmValorMenorQue1(double valorInvalido)
        {

            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComValor(valorInvalido).Build())
                .ComMensagem("Valor inválido");
        }

        public void Dispose()
        {

        }


    }

  

    
}
