import { connect } from 'react-redux'
import { getPortfolios, addPortfolios } from '../../actions/elections/ElectionAction'
import Portfolio from '../../components/portfolios'

const mapStateToProps = (state) => ({
  electionPortFolios: state.electionReducer.electionPortFolios
})

const mapDispatchToProps = (dispatch) => ({
  getPortfolios: (payload) => dispatch(getPortfolios(payload)),
  addPortfolios: (payload) => dispatch(addPortfolios(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(Portfolio)
