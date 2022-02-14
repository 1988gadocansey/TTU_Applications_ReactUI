import {Types} from './Types'
import API from "../../utils/api";

/*export const geLoggedInUser = (user) =>{
    console.log("action called ....")
    return {
        type: Types.GET_USER,
        payload: user
    }
}*/

export const  getFormData = (dispatch) => async () => {
    await API.get('/applicationform')
        .then((res) => {
            dispatch({
                type: Types.GET_USER,
                payload: res.data
            })
           
        }).catch((err) => {
          console.log("error",err)
        })
    
}
/*
export const  geLoggedInUser = (user) => async (dispatch) => {
    
    const token = await authService.getAccessToken();
    const response = await fetch('welcome', {
        headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    });
    const user = await response.json();
   dispatch( geLoggedInUser(user))
}*/
