import { connect } from 'react-redux'
import { setTokenData } from '../../actions/access-tokens/AccessTokenAction'
import Candidate from '../../components/candidates'

const mapStateToProps = (state) => ({

})

const mapDispatchToProps = (dispatch) => ({
  setTokenData: (payload) => dispatch(setTokenData(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(Candidate)
