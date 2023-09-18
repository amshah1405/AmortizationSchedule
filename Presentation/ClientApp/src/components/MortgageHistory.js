import React, { useState, useEffect } from 'react'; 
    const MortgageHistory = () => {
        const [mortgageHistory, setMortgageHistory] = useState([]);

        const formatCurrency = (value) => {
            if (value) {
                return value.toLocaleString('en-US', {
                    style: 'currency',
                    currency: 'USD',
                });
            } else {
                return "$0.00"
            }
        };

        const dateFormat = (value) => {

            if (value) {
                const dateObject = new Date(value);

                const year = dateObject.getFullYear();
                const month = String(dateObject.getMonth() + 1).padStart(2, '0');
                const day = String(dateObject.getDate()).padStart(2, '0');

                const formattedDatetime = `${month}/${day}/${year}`;
                return formattedDatetime;
            }
        };

        useEffect(() => {
            fetch('https://localhost:7182/api/Mortgage/retrieveHistory')
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    setMortgageHistory(data.$values);
                })
                .catch(error => {
                    console.error('Error fetching data:', error);
                });
        }, []);

        
        return (
            <div>
                {mortgageHistory ? (
                    <div>                         
                        <table className="table table-stripped border">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Loan Amount</th>
                                    <th>Annual Interest Rate</th>
                                    <th>Loan Term</th>
                                    <th>Start Date</th> 
                                </tr>
                            </thead>
                            <tbody>
                        {mortgageHistory.map((x) => ( 

                            <tr>
                                <td>  <a href={`/details/${x.mortgageID}`} >{x.mortgageID} </a></td>
                                <td>{formatCurrency(x.loanAmount)}</td>
                                <td>{formatCurrency(x.annualInterestRate)}</td>
                                <td>{x.loanTerm}</td>
                                <td>{dateFormat(x.startDate)}</td>
                                        </tr>
                        ))}
                            </tbody>

                        </table>
                        
                    </div>
                ) : (
                    <p>Loading...</p>
                )}
            </div>
        );
    };
export default MortgageHistory;