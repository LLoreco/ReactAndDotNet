import './App.css';
import Header from './myModules/Header';
import Footer from './myModules/Footer';
import Body from './myModules/Body';
import SideBar from './myModules/SideBar';
import theme from './theme/mainTheme';


function App() {

    //Для дэбага
    const task = {activeTask: 'ОЧЕНЬ ДЛИННЫЙ ТАСК', nextTask: 'Следующая задача', timer:'1:32'}


    const setThemeVariables = () => {
        const root = document.documentElement;

        root.style.setProperty('--sidebar-width', theme.sizes.width.sidebar)

        root.style.setProperty('--sidebar-color',theme.background.sidebarColor)
        root.style.setProperty('--header-color',theme.background.headerColor)
        root.style.setProperty('--footer-color',theme.background.footeColor)
        root.style.setProperty('--body-color',theme.background.bodyColor)

        root.style.setProperty('--sidebar-margin',theme.margins.sidebarMargin)
    }

    setThemeVariables();

    return (
        <div>
            <SideBar/>
            <Header activeTask={task.activeTask} nextTask={task.nextTask} timer={task.timer}/>
            <Body />
            <Footer />
        </div>
    );
}

export default App;