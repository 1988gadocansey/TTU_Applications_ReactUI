import { Types } from './Types'
export const uploadFile = (data) => () => {
    return new Promise((resolve, reject) => {
        api().post('/candidate/docs/upload', data).then((res) => {
            dispatch({
              type: Types.NEW_AVATAR,
              payload: res.data
            })
            resolve(res)
        }).catch((err) => {
            reject(err)
        })
    })
}
export const getAvatar = () =>{
    
}