using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Design_Patterns
{
    public enum DeveloperLevel
    {
        Senior,
        Junior
    }

    public class DeveloperReport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeveloperLevel Level { get; set; }
        public int WorkingHours { get; set; }
        public double HourlyRate { get; set; }
        public double CalculateSalary() => WorkingHours * HourlyRate;
    }

    public interface ISalaryCalculator
    {
        double CalculateTotalSalary(IEnumerable<DeveloperReport> reports);
    }


    public class JuniorDevSalaryCalculator : ISalaryCalculator
    {
        public double CalculateTotalSalary(IEnumerable<DeveloperReport> reports) =>
            reports
                .Where(r => r.Level == DeveloperLevel.Junior)
                .Select(r => r.CalculateSalary())
                .Sum();
    }

    public class SeniorDevSalaryCalculator : ISalaryCalculator
    {
        public double CalculateTotalSalary(IEnumerable<DeveloperReport> reports) =>
            reports
                .Where(r => r.Level == DeveloperLevel.Senior)
                .Select(r => r.CalculateSalary() * 1.2)
                .Sum();
    }

    public class SalaryCalculator
    {
        private ISalaryCalculator _calculator;
        public SalaryCalculator(ISalaryCalculator calculator)
        {
            _calculator = calculator;
        }
        public void SetCalculator(ISalaryCalculator calculator) => _calculator = calculator;
        public double Calculate(IEnumerable<DeveloperReport> reports) => _calculator.CalculateTotalSalary(reports);
    }


}
