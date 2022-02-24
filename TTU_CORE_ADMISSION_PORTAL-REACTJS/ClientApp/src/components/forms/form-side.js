import React from 'react'
import PropTypes from 'prop-types'
import { Divider, Steps, Tag } from 'antd'
import { useMediaQuery } from 'react-responsive'


const { Step } = Steps

export default function FormSide (props) {
  const isMobileOrTablet = useMediaQuery({ query: '(max-width: 767px)' })
  return (
      <div align={'center'}>
          {/*<PictureForm imageUrl={props.imageUrl} indexNumber={props.indexNumber} completed={props.completed}/>*/}
          
          <Divider style={{ margin: 5 }}/>
          <Tag color={'blue'}>
              {props.portfolio}
          </Tag>
          <Steps onChange={props.onChange} style={{ marginTop: 25 }} direction={isMobileOrTablet ? 'horizontal' : 'vertical'} size="small" current={props.current}>
              {props.steps.map(item => (
                  <Step key={item.title} title={item.title} description={item.subTitle}/>
              ))}
          </Steps>
      </div>

  )
}

FormSide.propTypes = {
  steps: PropTypes.array.isRequired,
  onChange: PropTypes.func.isRequired,
  portfolio: PropTypes.string,
  current: PropTypes.number.isRequired,
  imageUrl: PropTypes.string.isRequired,
  indexNumber: PropTypes.string.isRequired,
  completed: PropTypes.number.isRequired,
}
