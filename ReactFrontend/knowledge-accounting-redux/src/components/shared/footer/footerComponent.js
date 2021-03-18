import React, { Component } from 'react';
import './footerComponent.css';

export default class FooterComponent extends Component {
    render() {
        return (
            <footer className="page-footer sticky-top">
                <p id="footer-copyright" className="text-center">&copy; 2021 Copyright:
                    <a id="gitlab-link" href="https://gitlab.com/DmytroMeheda"
                        rel="noopener noreferrer"
                        target="_blank">Dmytro Meheda
                    </a>
                </p>
            </footer>
        )
    }
}