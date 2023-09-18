
import MortgageDetails from "./components/MortgageDetails";
import MortgageHistory from "./components/MortgageHistory" 

const AppRoutes = [
  {
        index: true,
        element: <MortgageDetails />
  },
   
    {
        path: '/mortgageHistory',
        element: <MortgageHistory />
    }
];

export default AppRoutes;
