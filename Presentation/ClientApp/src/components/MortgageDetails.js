import React, { useState }  from 'react';

const MortgageDetails = ({ onMortgageCalculation }) => {

    const [formData, setFormData] = useState({
        loanAmount: '',
        annualInterestRate: '',
        loanTerm: '',
        startDate: '',
    }); 
    const [calculatedMortgage, setCalculatedMortgage] = useState(null);
    
    const validateInput = (name, value) => {
        if (name === 'loanAmount') { 
            return value.trim() !== '' && !isNaN(value) && value >=0;
        } else if (name === 'annualInterestRate') {
            return value.trim() !== '' && !isNaN(value) && value >= 0;
        } else if (name === 'loanTerm') {
            return value.trim() !== '' && !isNaN(value) && value >= 0;
        } else if (name === 'startDate') { 
            return value.trim() !== '';
        }
        return false;
    };
 
    const handleInputChange = (e) => {
        const { name, value } = e.target;
        const inputValid = validateInput(name, value);
        setFormData({
            ...formData,
            [name]: value,
        }); 

        if (inputValid) {
            e.target.classList.remove('invalid-input');
        } else {
            e.target.classList.add('invalid-input');
        } 

    };

    const calculate = () => { 
        const allInputsValid = Object.keys(formData).every((key) =>
            validateInput(key, formData[key])
        ); 
        if (allInputsValid) {
            calculateMortgagePayment();
        } 
    }; 
    const calculateMortgagePayment = async () => { 

        try {
            const apiUrl = "https://localhost:7182/api/Mortgage/calculate";  
            const response = await fetch(apiUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formData),  
            });


            const responseData = await response.json();
            setCalculatedMortgage(responseData.mortagePaymentDetails[0]);
            onMortgageCalculation(responseData);
        } catch (error) {
            console.error('Error posting data:', error);
        } 
    };

    return ( 
        <div className="container">
            <div className="row">
            <div class="col-md-4">
                <table className='table table-striped border' aria-labelledby="tabelLabel">

                    <tbody>
                        <tr>
                            <td class="col-md-2 border-end"> <b>Loan Amount </b></td>
                                <td class="col-md-2"><input type="text"
                                    name="loanAmount"
                                    placeholder="Loan Amount"
                                    value={formData.loanAmount}
                                    onChange={handleInputChange}></input> </td>
                        </tr>
                        <tr>
                            <td class="col-md-2 border-end"> <b>Interest Rate</b></td>
                                <td class="col-md-2"><input type="text"
                                    name="annualInterestRate"
                                    placeholder="Interest Rate"
                                    value={formData.annualInterestRate}
                                    onChange={handleInputChange}></input> </td>
                        </tr>
                        <tr>
                            <td class="col-md-2 border-end"> <b>Term</b></td>
                                <td class="col-md-2"><input type="text"
                                    name="loanTerm"
                                    placeholder="Loan Term"
                                    value={formData.loanTerm}
                                    onChange={handleInputChange}></input> </td>
                        </tr>
                        <tr>
                            <td class="col-md-2 border-end"> <b>Loan Starting Date</b></td>
                                <td class="col-md-2"><input type="date"
                                    name="startDate"
                                    placeholder="Loan Start Date"
                                    value={formData.loanStartDate}
                                    onChange={handleInputChange}></input> </td>
                        </tr>
                    </tbody>
                    </table>
                     
                    <button onClick={calculate}  >
                        Calculate Mortgage Payment
                    </button>

                   
               
                </div>
            </div>
        </div>
        );
    }
export default MortgageDetails;
