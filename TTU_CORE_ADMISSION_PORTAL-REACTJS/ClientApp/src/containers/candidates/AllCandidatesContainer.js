import { connect } from 'react-redux'
import { deleteToken, getAllTokens, restoreToken } from '../../actions/access-tokens/AccessTokenAction'
import AllCandidates from '../../components/candidates/all-candidates'

const mapStateToProps = (state) => ({
  accessTokens: state.accessTokenReducer.accessTokens
})

const mapDispatchToProps = (dispatch) => ({
  getAllTokens: (payload) => dispatch(getAllTokens(payload)),
  deleteToken: (payload) => dispatch(deleteToken(payload)),
  restoreToken: (payload) => dispatch(restoreToken(payload)),
})

export default connect(mapStateToProps, mapDispatchToProps)(AllCandidates)
