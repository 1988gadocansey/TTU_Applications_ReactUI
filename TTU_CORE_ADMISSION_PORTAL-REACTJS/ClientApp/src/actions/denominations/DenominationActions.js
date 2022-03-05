import { Types } from './Types'
import API from "../../utils/api";
export const  getDenomination = (dispatch) => async () => {
    await API.get('/api/selectbox/denomination')
        .then((res) => {
            dispatch({
                type: Types.GET_DENOMINATION,
                payload: res.data
            })

        }).catch((err) => {
            console.log("error",err)
        })
    

}
 