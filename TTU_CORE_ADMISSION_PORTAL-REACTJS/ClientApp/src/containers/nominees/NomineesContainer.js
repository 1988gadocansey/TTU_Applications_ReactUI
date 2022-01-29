import { connect } from 'react-redux'
import { setTokenData } from '../../actions/access-tokens/AccessTokenAction'
import Nominees from '../../components/nominees'

const mapStateToProps = (state) => ({

})

const mapDispatchToProps = (dispatch) => ({
  setTokenData: (payload) => dispatch(setTokenData(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(Nominees)
