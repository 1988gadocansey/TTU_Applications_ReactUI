import { connect } from 'react-redux'
import AccessTokens from '../../components/access-tokens'
import { setTokenData } from '../../actions/access-tokens/AccessTokenAction'

const mapStateToProps = (state) => ({

})

const mapDispatchToProps = (dispatch) => ({
  setTokenData: (payload) => dispatch(setTokenData(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(AccessTokens)
