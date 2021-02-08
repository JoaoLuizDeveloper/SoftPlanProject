using MediatR;

namespace SoftPlanAPI.Services
{
    public class CalcTaxes : IRequest<decimal>
    {
        public decimal InitialValue { get; private set; }

        public int QtdMonths { get; private set; }

        public decimal InterestTaxes { get; private set; }

        #region Factory

        public static class Factory
        {
            public static CalcTaxes Create(decimal initialValue, int qtdMonths, decimal interestTaxes)
                => new CalcTaxes()
                {
                    InitialValue = initialValue,
                    QtdMonths = qtdMonths,
                    InterestTaxes = interestTaxes
                };
        }

        #endregion

    }
}