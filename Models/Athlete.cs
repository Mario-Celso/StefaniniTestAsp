using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StefaniniTestAsp.Models
{
    public class Athlete
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Nickname { get; set; }
        public DateTime BirthDate { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string? Position { get; set; }
        public int ShirtNumber { get; set; }

        [NotMapped]
        public int Age => CalculateAge();

        [NotMapped]
        public double IMC => CalculateIMC();

        [NotMapped]
        public string? IMCClassification => ClassifyIMC();


        private int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - BirthDate.Year;
            if (BirthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        private double CalculateIMC()
        {
            if (Height <= 0 || Weight <= 0)
                return 0;

            // Convertendo altura de centímetros para metros
            double heightInMeters = Height / 100.0;
            double imc = Weight / (heightInMeters * heightInMeters);
            return Math.Round(imc, 2);
        }

        private string ClassifyIMC()
        {
            double imc = CalculateIMC();

            if (imc < 18.5)
                return "Abaixo do Peso";
            else if (imc < 24.9)
                return "Peso Normal";
            else if (imc < 29.9)
                return "Sobrepeso";
            else if (imc < 34.9)
                return "Obesidade Grau I";
            else if (imc < 39.9)
                return "Obesidade Grau II";
            else
                return "Obesidade Grau III (Obesidade Mórbida)";
        }
    }
}
