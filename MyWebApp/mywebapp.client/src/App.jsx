import './App.css';
import Header from './myModules/Header';
import Body from './myModules/Body';
import SideBar from './myModules/SideBar';
import theme from './theme/mainTheme';


function App() {

    //Для дэбага
    const task = {activeTask: 'ОЧЕНЬ ДЛИННЫЙ ТАСК', nextTask: 'Следующая задача', timer:'1:32'}
    const setThemeVariables = () => {
        const root = document.documentElement;
        //width
        root.style.setProperty('--sidebar-width', theme.sizes.width.sidebar)

        //height
        root.style.setProperty('--sidebar-height',theme.sizes.height.sidebar)
        root.style.setProperty('--sidebar-logo-height',theme.sizes.height.sidebarLogo)
        root.style.setProperty('--header-height',theme.sizes.height.header)
        root.style.setProperty('--body-height',theme.sizes.height.body)

        //color
        root.style.setProperty('--sidebar-color',theme.background.sidebarColor)
        root.style.setProperty('--header-color',theme.background.headerColor)
        root.style.setProperty('--body-color',theme.background.bodyColor)
        root.style.setProperty('--active-task-color',theme.background.activeTask)
        root.style.setProperty('--next-task-color',theme.background.nextTask)
        root.style.setProperty('--create-task-button-color',theme.background.createTaskButton)
        root.style.setProperty('--action-button-color', theme.background.actionButton)

        //margins
        root.style.setProperty('--sidebar-margin',theme.margins.sidebarMargin)
        root.style.setProperty('--sidebar-content-margin',theme.margins.sidebarContenMargin)

        //paddings
        root.style.setProperty('--sidebar-padding',theme.paddings.sidebar)
        root.style.setProperty('--header-active-task-padding',theme.paddings.headerActiveTask)
        root.style.setProperty('--header-next-task-padding',theme.paddings.nextTask)
        root.style.setProperty('--create-task-button-padding',theme.paddings.createTaskButton)

        //text
        root.style.setProperty('--next-task-timer-color',theme.text.color.nextTaskTimer)

        //table
        root.style.setProperty('--task-table-border-color', theme.table.color.border)
    }

    setThemeVariables();

    return (
        <div>
            <SideBar/>
            {/* <Header activeTask={task.activeTask} nextTask={task.nextTask} timer={task.timer}/> */}
            {/* <Header activeTask={activeTask} nextTask={task.nextTask} timer={timer}/> */
            <Header />}
            <Body />
            {/* <Footer /> */}
        </div>
    );
}

export default App;