import Cookies from 'js-cookie'
import { Store } from './Store'
import cookie from 'cookie'
import api from './api'
export const isLoggedIn = (reqCookies = null) => {
  // if we don't have request cookies, get the cookie from client
  if (!reqCookies) {
    return !!Cookies.get('userLoggedIn')
  }

  // otherwise get cookie from server
  return !!cookie.parse(reqCookies).userLoggedIn
}

export const uploadImage = (path = 'upload', data) => {
  return new Promise((resolve, reject) => {
    api().post(`/nominee/${path}`, data).then((res) => {
      resolve(res)
    }).catch((err) => {
      reject(err)
    })
  })
}

export const getAge = (dateString) => {
  const today = new Date()
  const birthDate = new Date(dateString)
  let age = today.getFullYear() - birthDate.getFullYear()
  const m = today.getMonth() - birthDate.getMonth()
  if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
    age--
  }
  return age
}

export const activeRoles = () => {
  const state = Store.getState()
  console.log(state)
  return state.userReducer.activeRoles
}
