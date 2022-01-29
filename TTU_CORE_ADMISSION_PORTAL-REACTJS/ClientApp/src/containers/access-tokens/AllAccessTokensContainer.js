import { connect } from 'react-redux'
import AllAccessTokens from '../../components/access-tokens/all-access-tokens'
import { deleteToken, getAllTokens, restoreToken } from '../../actions/access-tokens/AccessTokenAction'

const mapStateToProps = (state) => ({
  accessTokens: state.accessTokenReducer.accessTokens
})

const mapDispatchToProps = (dispatch) => ({
  getAllTokens: (payload) => dispatch(getAllTokens(payload)),
  deleteToken: (payload) => dispatch(deleteToken(payload)),
  restoreToken: (payload) => dispatch(restoreToken(payload)),
})

export default connect(mapStateToProps, mapDispatchToProps)(AllAccessTokens)
