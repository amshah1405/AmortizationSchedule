
import MortgageDetails from "./components/MortgageDetails";
import MonthlyPaymentDetails from "./components/MonthlyPaymentList" 

const AppRoutes = [
  {
        index: true,
        element: <MortgageDetails />
  },
   
    {
        path: '/monthlypayments',
        element: <MonthlyPaymentDetails />
    }
];

export default AppRoutes;
