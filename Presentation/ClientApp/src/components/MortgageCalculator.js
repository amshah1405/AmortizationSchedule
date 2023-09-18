import React, { useState } from 'react'; 
import MortgageDetails from './MortgageDetails';
import MortgagePaymentDetails from './MonthlyPaymentList';

const MortgageCalculator = () => {


    const [mortgagePaymentList, setMonthlyPaymentDetails] = useState([]);
    const [dataLoaded, setDataLoaded] = useState(false);

    const calculateMortgage = (data) => {
        setMonthlyPaymentDetails(data.mortagePaymentDetails.$values);
        setDataLoaded(data.mortagePaymentDetails.$values.length > 0);
    };

    return (
        < div > 
            <MortgageDetails onMortgageCalculation={calculateMortgage} />
           { dataLoaded ? <MortgagePaymentDetails mortgagePaymentList={mortgagePaymentList} /> : <></> }
           </div>
  
    );

}
export default MortgageCalculator;