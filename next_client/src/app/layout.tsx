import "./globals.scss";
import {ReactNode} from "react";

const RootLayout = ({children}: {children: ReactNode}) => {
    return (
        <html lang="en">
            <body>
                <div className="body-content">{children}</div>
            </body>
        </html>
    );
};

export default RootLayout;
