import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'; // Import Routes
import { Layout } from './components/Layout';
import './custom.css';
import MortgageCalculator from './components/MortgageCalculator'; 
import MortgageHistory from './components/MortgageHistory';

const App = () => {

        return (
            <Layout>
               
                    <Routes>
                        <Route path="/" element={<MortgageCalculator />} />
                    <Route path="/mortgageHistory" element={<MortgageHistory />} /> 
                    </Routes>
                
               
            </Layout>
        );
   
}
export default App;