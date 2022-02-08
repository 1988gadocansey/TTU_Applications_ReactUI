import {useDispatch, useSelector} from "react-redux";
import authService from "../components/api-authorization/AuthorizeService";
import {geLoggedInUser} from "../actions/user/UsersAction";

  

export const fetchUser = async () => {
    await authService.getUser().then((res) => {
        return  JSON.stringify(res)
    }).then()
}

