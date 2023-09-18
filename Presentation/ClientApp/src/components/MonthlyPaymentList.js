
const MonthlyPaymentDetails = ({ mortgagePaymentList }) => {
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

    return (

        <div className="container">

            <div className="row">
                <div class="col-md-4">
                    <table className='table table-striped border mt-3' aria-labelledby="tabelLabel">

                        <tbody>
                            <tr> <td class="col-md-2 border-end"> <b>Monthly Payment</b></td>
                                <td class="col-md-2">  {mortgagePaymentList.length > 0 ? formatCurrency(mortgagePaymentList[0].monthlyPayment) : ""}   </td>
                            </tr >
                            <tr>
                                <td class="col-md-2 border-end"> <b>Loan End Date</b></td>
                                <td class="col-md-2"> {mortgagePaymentList.length > 0 ? dateFormat(mortgagePaymentList[mortgagePaymentList.length - 1].paymentDate) : ""}   </td>
                            </tr >

                        </tbody>
                    </table>
                </div>
            </div>


            <div className="row">
                <div className="col-sm-12">

                    <table className="table table-stripped border">
                        <thead>
                            <tr>
                                <th></th>
                                <th>Payment Date</th>
                                <th>Balance</th>
                                <th>Principal</th>
                                <th>Interest</th>
                                <th>Payment</th>
                                <th>Total Interest</th>
                                <th>Total Paid</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                mortgagePaymentList.map((item) => (
                                    <tr>
                                        <td></td>
                                        <td>{dateFormat(item.paymentDate)}</td>
                                        <td>{formatCurrency(item.remainingBalance)}</td>
                                        <td>{formatCurrency(item.principalAmt)}</td>
                                        <td>{formatCurrency(item.monthlyInterest)}</td>
                                        <td>{formatCurrency(item.monthlyPayment)}</td>
                                        <td>{formatCurrency(item.totalInterest)}</td>
                                        <td>{formatCurrency(item.totalPaid)}</td>
                                    </tr>
                                ))
                            }
                        </tbody>

                    </table>
                </div>
            </div>
        </div>
    )
}
export default MonthlyPaymentDetails;