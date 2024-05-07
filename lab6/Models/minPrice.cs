using System.ComponentModel.DataAnnotations;

namespace lab6
{
    public class minPrice : ValidationAttribute
    {
        int PriceValue;

        public minPrice(int num)
        {
            PriceValue = num;
        }

        public override bool IsValid(object obj)
        {
            if(obj is null)
            {
                ErrorMessage = "the min price of any order is "+PriceValue;
                return false;
            }
            else 
            {
                if(obj is int)
                {
                    int suppliedValue = (int)obj;
                    if(suppliedValue > PriceValue)
                    {
                        return true;
                    }
                    else 
                    {
                        ErrorMessage = "the min price of any order is "+PriceValue;

                        return false;
                    }
                }
                else 
                {
                    ErrorMessage = "Price Should be Int Value!!";
                    return false;
                }
            }
        }
    }
}
