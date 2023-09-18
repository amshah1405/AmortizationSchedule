import React, { useState, useEffect } from 'react';

const AccordionItem = ({ title, content, isOpen, toggleAccordion }) => (
    <div className={`accordion-item ${isOpen ? 'open' : ''}`}>
        <div className="accordion-header" onClick={toggleAccordion}>
            {title}
            <span className={`icon ${isOpen ? 'open' : ''}`}>▼</span>
        </div>
        {isOpen && <div className="accordion-content">{content}</div>}
    </div>
);

 

    const MortgageHistory = () => {
        const [mortgageHistory, setMortgageHistory] = useState([]);
        const [activeIndex, setActiveIndex] = useState(null);

        useEffect(() => {
            fetch('https://localhost:7182/api/Mortgage/retrieveHistory')
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    setMortgageHistory(data);
                })
                .catch(error => {
                    console.error('Error fetching data:', error);
                });
        }, []);

        const toggleAccordion = (index) => () => {
            setActiveIndex(index === activeIndex ? null : index);
        };
        return (
            <div className="accordion">
                {mortgageHistory.map((item, index) => (
                    <AccordionItem
                        key={index}
                        title={item.title}
                        content={item.content}
                        isOpen={index === activeIndex}
                        toggleAccordion={toggleAccordion(index)}
                    />
                ))}
            </div>
        );
    };
export default MortgageHistory;