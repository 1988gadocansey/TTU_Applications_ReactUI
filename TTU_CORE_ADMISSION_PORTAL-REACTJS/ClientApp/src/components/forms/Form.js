import React, {useEffect, useState} from "react";
import {Steps, Button, message} from 'antd';
import FirstStep from "./FirstStep";
import SecondStep from "./SecondStep";
import ThirdStep from "./ThirdStep";

const {Step} = Steps;

const steps = [
    {
        title: 'First',
        content: <FirstStep />
    },
    {
        title: 'Second',
        content: <SecondStep/>
    },
    {
        title: 'Last',
        content: <ThirdStep/>
    },
];

const Forms = () => {
    const [current, setCurrent] = React.useState(0);

    const next = () => {
        setCurrent(current + 1);
    };

    const prev = () => {
        setCurrent(current - 1);
    };

    return (
        <>
           
                <div className="ant-card">
                    <div className="ant-card-body">
                        <mark>Fields marked in red asteriks(*) are required.</mark>
                        <Steps current={current}>
                            {steps.map(item => (
                                <Step key={item.title} title={item.title}/>
                            ))}
                        </Steps>
                        <div className="steps-contents">{steps[current].content}</div>
                        <div className="steps-action">
                            {current < steps.length - 1 && (
                                <Button type="primary" onClick={() => next()}>
                                    Next
                                </Button>
                            )}
                            {current === steps.length - 1 && (
                                <Button type="primary" onClick={() => message.success('Processing complete!')}>
                                    Done
                                </Button>
                            )}
                            {current > 0 && (
                                <Button style={{margin: '0 8px'}} onClick={() => prev()}>
                                    Previous
                                </Button>
                            )}
                        </div>
                    </div>
                </div>
             
        </>
    );
};
export default Forms
