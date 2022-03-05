import { Types } from './Types'
import API from "../../utils/api";
export const  getProgrammes = (dispatch) => async () => {
    await API.get('/api/selectbox/programmes')
        .then((res) => {
            dispatch({
                type: Types.GET_PROGRAMME,
                payload: res.data
            })

        }).catch((err) => {
            console.log("error",err)
        })
    

}


 
 