import './components/App.css';
import Home from "./components/Home";
import {BrowserRouter, Route} from 'react-router-dom'
import Form from "./components/forms/Form";
import PictureUpload from "./components/avatar/PictureUpload";
import ResultUpload from "./components/forms/ResultUpload";
import PrintPreview from "./components/print/PrintPreview";
import Index from "./components/layouts/Index";
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import {FetchData} from "./components/FetchData";

function App() {
    const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');

    return (

      <div className="App">
        <BrowserRouter  basename={baseUrl}>
          <div>
            <Index>
              <Route path="/" exact={true} component={Home}/>
              <Route path="/home" exact={true} component={Home}/>
              <Route path="/pictureUpload" component={PictureUpload}/>
              <Route path="/form/fill" component={Form}/>
              <Route path="/resultUpload" component={ResultUpload}/>
             
                <AuthorizeRoute path='/fetch-data' component={FetchData} />
                <AuthorizeRoute path='/preview' component={PrintPreview} />
                <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />

            </Index>
          </div>
        </BrowserRouter>

      </div>


  );
}

export default App;
