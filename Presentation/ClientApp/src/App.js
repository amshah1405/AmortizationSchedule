import React, { useState } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'; // Import Routes
import { Layout } from './components/Layout';
import './custom.css';
import MortgageCalculator from './components/MortgageCalculator'; 
import MortgageHistory from './components/MortgageHistory';
const App = () => {

     
  /*  const [mortgagePaymentList, setMonthlyPaymentDetails] = useState([]);
    const [dataLoaded, setDataLoaded] = useState(false);
    
            const calculateMortgage = (data) => {
                setMonthlyPaymentDetails(data.mortagePaymentDetails);
                setDataLoaded(data.mortagePaymentDetails.length > 0);                
            };
            */
        return (
            <Layout>
               
                    <Routes>
                        <Route path="/" element={<MortgageCalculator />} />
                        <Route path="/about" element={<MortgageHistory />} /> 
                    </Routes>
                
                {/*<MortgageDetails onMortgageCalculation={calculateMortgage} />*/}
                {/*{dataLoaded ? <MortgagePaymentDetails mortgagePaymentList={mortgagePaymentList} /> : <></>} */}
               
            </Layout>
        );
   
}
export default App;