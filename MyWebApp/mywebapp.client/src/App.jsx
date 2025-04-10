import './App.css';
import Header from './myModules/Header';
import Footer from './myModules/Footer';
import Body from './myModules/Body';
import SideBar from './myModules/SideBar';
import theme from './theme/mainTheme';


function App() {

    const setThemeVariables = () => {
        const root = document.documentElement;

        root.style.setProperty('--sidebar-width', theme.sizes.width.sidebar)
        root.style.setProperty('--sidebar-color',theme.background.sidebarColor)
        root.style.setProperty('--header-color',theme.background.headerColor)
        root.style.setProperty('--footer-color',theme.background.footeColor)
        root.style.setProperty('--body-color',theme.background.bodyColor)
    }

    setThemeVariables();

    return (
        <div>
            <SideBar/>
            <Header />
            {/* <Body /> */}
            <Footer />
        </div>
    );
}

export default App;