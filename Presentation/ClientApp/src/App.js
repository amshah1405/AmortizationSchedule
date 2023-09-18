import React, { useState} from 'react';
import { Layout } from './components/Layout';
import './custom.css';
import MortgageDetails from './components/MortgageDetails';
import MortgagePaymentDetails from './components/MonthlyPaymentList';

const App = () => {

     
    const [mortgagePaymentList, setMonthlyPaymentDetails] = useState([]);
    const [dataLoaded, setDataLoaded] = useState(false);
    
            const calculateMortgage = (data) => {
                setMonthlyPaymentDetails(data.mortagePaymentDetails);
                setDataLoaded(data.mortagePaymentDetails.length > 0);                
            };

        return (
            <Layout>
                <MortgageDetails onMortgageCalculation={calculateMortgage} />
                {dataLoaded ? <MortgagePaymentDetails mortgagePaymentList={mortgagePaymentList} /> : <></>} 
               
            </Layout>
        );
   
}
export default App;