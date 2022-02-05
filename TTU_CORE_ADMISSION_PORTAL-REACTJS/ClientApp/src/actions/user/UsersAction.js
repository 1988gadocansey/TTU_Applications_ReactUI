import {Types} from './Types'
export const geLoggedInUser = (user) =>{
    console.log("action called ....")
    return {
        type: Types.GET_USER,
        payload: user
    }
}

