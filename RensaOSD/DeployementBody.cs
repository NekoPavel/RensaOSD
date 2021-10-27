using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RensaOSD
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Settings
    {
        public bool canClose { get; set; }
        public bool oneMessageOnly { get; set; }
        public bool validate { get; set; }
        public bool alwaysUseExecuteData { get; set; }
        public bool addVerification { get; set; }
    }

    public class MessageTracker
    {
        public Settings _settings { get; set; }
        public bool canClose { get; set; }
        public List<object> currentErrors { get; set; }
        public List<object> warnings { get; set; }
        public List<object> success { get; set; }
        public bool hasErrors { get; set; }
        public bool hasWarnings { get; set; }
        public bool hasSuccess { get; set; }
        public bool hasAny { get; set; }
    }

    public class Settings2
    {
        public bool canClose { get; set; }
        public bool oneMessageOnly { get; set; }
        public bool validate { get; set; }
        public bool alwaysUseExecuteData { get; set; }
        public bool addVerification { get; set; }
    }

    public class Pagination
    {
        public int pagingTake { get; set; }
        public int currentIndex { get; set; }
    }

    public class SearchType
    {
        public int value { get; set; }
        public string name { get; set; }
    }

    public class SelectedSearchType
    {
        public int value { get; set; }
        public string name { get; set; }
    }

    public class FileToUpload
    {
    }

    public class EmptyReporter
    {
    }

    public class SearchReporter
    {
    }

    public class VerificationDeferred
    {
    }

    public class BrowseMore
    {
        public Settings _settings { get; set; }
        public VerificationDeferred _verificationDeferred { get; set; }
        public bool isVerificationVisible { get; set; }
        public bool canExecute { get; set; }
        public bool canExecuteVerification { get; set; }
        public bool isExecuting { get; set; }
    }

    public class ViewModel
    {
        public MessageTracker messageTracker { get; set; }
        public bool canClose { get; set; }
        public List<object> currentErrors { get; set; }
        public List<object> success { get; set; }
        public bool hasErrors { get; set; }
        public List<object> warnings { get; set; }
        public bool hasWarnings { get; set; }
        public bool hasSuccess { get; set; }
        public Settings settings { get; set; }
        public Pagination pagination { get; set; }
        public bool hasLargeTag { get; set; }
        public List<SearchType> searchTypes { get; set; }
        public SelectedSearchType selectedSearchType { get; set; }
        public List<object> modules { get; set; }
        public List<object> acceptedFiles { get; set; }
        public bool hasFocus { get; set; }
        public List<object> searchResult { get; set; }
        public string searchInputText { get; set; }
        public FileToUpload fileToUpload { get; set; }
        public bool labelIsSrOnly { get; set; }
        public string searchInputLabel { get; set; }
        public string searchInputPlaceholder { get; set; }
        public bool canSearch { get; set; }
        public bool emptySearchResult { get; set; }
        public bool isSearching { get; set; }
        public bool isSearchType { get; set; }
        public bool isFileType { get; set; }
        public int searchTotalCount { get; set; }
        public int searchResultTotalCountOnFetch { get; set; }
        public bool extraMessageIsEnabled { get; set; }
        public bool canBrowse { get; set; }
        public bool automaticSelectionOfFirstEntry { get; set; }
        public int limitSearchResultCount { get; set; }
        public bool limitSearchResult { get; set; }
        public List<object> limitedSearchResult { get; set; }
        public bool isResultLimitReached { get; set; }
        public List<object> selectedItems { get; set; }
        public bool hasSelectedItem { get; set; }
        public object selectedItem { get; set; }
        public EmptyReporter emptyReporter { get; set; }
        public SearchReporter searchReporter { get; set; }
        public BrowseMore browseMore { get; set; }
    }

    public class SearchViewModel
    {
        public string title { get; set; }
        public ViewModel viewModel { get; set; }
    }

    public class SearchViewModel2
    {
        public object title { get; set; }
        public object viewModel { get; set; }
    }

    public class Mode
    {
        public bool isActive { get; set; }
        public string label { get; set; }
        public bool isVisible { get; set; }
        public bool isDisabled { get; set; }
    }

    public class SelectedMode
    {
        public bool isActive { get; set; }
        public string label { get; set; }
        public bool isVisible { get; set; }
        public bool isDisabled { get; set; }
    }

    public class SearchViewModelTracker
    {
        public List<Mode> modes { get; set; }
        public SelectedMode selectedMode { get; set; }
        public bool hasSelectedMode { get; set; }
    }

    public class Remove
    {
        public Settings _settings { get; set; }
        public VerificationDeferred _verificationDeferred { get; set; }
        public bool isVerificationVisible { get; set; }
        public bool canExecute { get; set; }
        public bool canExecuteVerification { get; set; }
        public bool isExecuting { get; set; }
    }

    public class Select
    {
        public Settings _settings { get; set; }
        public VerificationDeferred _verificationDeferred { get; set; }
        public bool isVerificationVisible { get; set; }
        public bool canExecute { get; set; }
        public bool canExecuteVerification { get; set; }
        public bool isExecuting { get; set; }
    }

    public class PrimaryUsersPicker
    {
        public string title { get; set; }
        public bool isTypeaheadEnabled { get; set; }
        public object typeaheadSearchViewModel { get; set; }
        public bool isLoading { get; set; }
        public string selectLabel { get; set; }
        public bool showSelect { get; set; }
        public bool singleSelect { get; set; }
        public List<SearchViewModel> searchViewModels { get; set; }
        public SearchViewModel searchViewModel { get; set; }
        public bool hasFocus { get; set; }
        public SearchViewModelTracker searchViewModelTracker { get; set; }
        public List<object> currentSelectedItems { get; set; }
        public List<object> selectedItems { get; set; }
        public object selectedItem { get; set; }
        public bool hasSelectedItem { get; set; }
        public List<object> itemsToAdd { get; set; }
        public List<object> itemsToRemove { get; set; }
        public object addOn { get; set; }
        public bool hasAddon { get; set; }
        public string placeholder { get; set; }
        public bool canSelect { get; set; }
        public bool canClearSelection { get; set; }
        public Remove remove { get; set; }
        public Select select { get; set; }
        public List<object> searchResult { get; set; }
    }

    public class ManagedByPicker
    {
        public string title { get; set; }
        public bool isTypeaheadEnabled { get; set; }
        public object typeaheadSearchViewModel { get; set; }
        public bool isLoading { get; set; }
        public string selectLabel { get; set; }
        public bool showSelect { get; set; }
        public bool singleSelect { get; set; }
        public List<SearchViewModel> searchViewModels { get; set; }
        public SearchViewModel searchViewModel { get; set; }
        public bool hasFocus { get; set; }
        public SearchViewModelTracker searchViewModelTracker { get; set; }
        public List<object> currentSelectedItems { get; set; }
        public List<object> selectedItems { get; set; }
        public object selectedItem { get; set; }
        public bool hasSelectedItem { get; set; }
        public List<object> itemsToAdd { get; set; }
        public List<object> itemsToRemove { get; set; }
        public object addOn { get; set; }
        public bool hasAddon { get; set; }
        public string placeholder { get; set; }
        public bool canSelect { get; set; }
        public bool canClearSelection { get; set; }
        public Remove remove { get; set; }
        public Select select { get; set; }
        public List<object> searchResult { get; set; }
    }

    public class DeployementBody
    {
        public DeployementBody(IdLookup idLookup, PcLookup pcLookup, bool installationType, InfoLookup infoLookup)
        {
            this.primaryUsersPicker = JsonSerializer.Deserialize<PrimaryUsersPicker>("{\"title\":\"Välj primäranvändare\",\"isTypeaheadEnabled\":false,\"typeaheadSearchViewModel\":null,\"isLoading\":false,\"selectLabel\":\"Lägg till\",\"showSelect\":true,\"singleSelect\":false,\"searchViewModels\":[{\"title\":\"\",\"viewModel\":{\"messageTracker\":{\"_settings\":{\"canClose\":true,\"oneMessageOnly\":true,\"validate\":false,\"alwaysUseExecuteData\":false,\"addVerification\":false},\"canClose\":true,\"currentErrors\":[],\"warnings\":[],\"success\":[],\"hasErrors\":false,\"hasWarnings\":false,\"hasSuccess\":false,\"hasAny\":false},\"canClose\":true,\"currentErrors\":[],\"success\":[],\"hasErrors\":false,\"warnings\":[],\"hasWarnings\":false,\"hasSuccess\":false,\"settings\":{\"canClose\":false,\"oneMessageOnly\":false,\"validate\":false,\"alwaysUseExecuteData\":false,\"addVerification\":false},\"pagination\":{\"pagingTake\":15,\"currentIndex\":0},\"hasLargeTag\":false,\"searchTypes\":[{\"value\":0,\"name\":\"Alla\"},{\"value\":1,\"name\":\"Namn\"},{\"value\":2,\"name\":\"Visningsnamn\"}],\"selectedSearchType\":{\"value\":0,\"name\":\"Alla\"},\"modules\":[],\"acceptedFiles\":[],\"hasFocus\":false,\"searchResult\":[],\"searchInputText\":\"\",\"fileToUpload\":{},\"labelIsSrOnly\":true,\"searchInputLabel\":\"Sök användare\",\"searchInputPlaceholder\":\"Sök användare...\",\"canSearch\":true,\"emptySearchResult\":false,\"isSearching\":false,\"isSearchType\":true,\"isFileType\":false,\"searchTotalCount\":0,\"searchResultTotalCountOnFetch\":0,\"extraMessageIsEnabled\":false,\"canBrowse\":false,\"automaticSelectionOfFirstEntry\":true,\"limitSearchResultCount\":150,\"limitSearchResult\":false,\"limitedSearchResult\":[],\"isResultLimitReached\":false,\"selectedItems\":[],\"hasSelectedItem\":false,\"selectedItem\":null,\"emptyReporter\":{},\"searchReporter\":{},\"browseMore\":{\"_settings\":{\"canClose\":false,\"oneMessageOnly\":false,\"validate\":false,\"alwaysUseExecuteData\":false,\"addVerification\":false},\"_verificationDeferred\":{},\"isVerificationVisible\":false,\"canExecute\":false,\"canExecuteVerification\":true,\"isExecuting\":false}}}],\"searchViewModel\":{\"title\":null,\"viewModel\":null},\"hasFocus\":false,\"searchViewModelTracker\":{\"modes\":[{\"isActive\":true,\"label\":\"\",\"isVisible\":true,\"isDisabled\":false}],\"selectedMode\":{\"isActive\":true,\"label\":\"\",\"isVisible\":true,\"isDisabled\":false},\"hasSelectedMode\":true},\"currentSelectedItems\":[],\"selectedItems\":[],\"selectedItem\":null,\"hasSelectedItem\":false,\"itemsToAdd\":[],\"itemsToRemove\":[],\"addOn\":null,\"hasAddon\":false,\"placeholder\":\"Inga primäranvändare valda...\",\"canSelect\":true,\"canClearSelection\":true,\"remove\":{\"_settings\":{\"canClose\":false,\"oneMessageOnly\":false,\"validate\":false,\"alwaysUseExecuteData\":false,\"addVerification\":false},\"_verificationDeferred\":{},\"isVerificationVisible\":false,\"canExecute\":true,\"canExecuteVerification\":true,\"isExecuting\":false},\"select\":{\"_settings\":{\"canClose\":false,\"oneMessageOnly\":false,\"validate\":false,\"alwaysUseExecuteData\":false,\"addVerification\":true},\"_verificationDeferred\":{},\"isVerificationVisible\":false,\"canExecute\":true,\"canExecuteVerification\":false,\"isExecuting\":false},\"searchResult\":[]}");
            this.managedByPicker = JsonSerializer.Deserialize<ManagedByPicker>("{\"title\":\"Välj resurs\",\"isTypeaheadEnabled\":false,\"typeaheadSearchViewModel\":null,\"isLoading\":false,\"selectLabel\":\"Välj\",\"showSelect\":true,\"singleSelect\":true,\"searchViewModels\":[{\"title\":\"Användare\",\"viewModel\":{\"messageTracker\":{\"_settings\":{\"canClose\":true,\"oneMessageOnly\":true,\"validate\":false,\"alwaysUseExecuteData\":false,\"addVerification\":false},\"canClose\":true,\"currentErrors\":[],\"warnings\":[],\"success\":[],\"hasErrors\":false,\"hasWarnings\":false,\"hasSuccess\":false,\"hasAny\":false},\"canClose\":true,\"currentErrors\":[],\"success\":[],\"hasErrors\":false,\"warnings\":[],\"hasWarnings\":false,\"hasSuccess\":false,\"settings\":{\"canClose\":false,\"oneMessageOnly\":false,\"validate\":false,\"alwaysUseExecuteData\":false,\"addVerification\":false},\"pagination\":{\"pagingTake\":15,\"currentIndex\":0},\"hasLargeTag\":false,\"searchTypes\":[{\"value\":0,\"name\":\"Alla\"},{\"value\":1,\"name\":\"Namn\"},{\"value\":2,\"name\":\"Visningsnamn\"}],\"selectedSearchType\":{\"value\":0,\"name\":\"Alla\"},\"modules\":[],\"acceptedFiles\":[],\"hasFocus\":false,\"searchResult\":[],\"searchInputText\":\"\",\"fileToUpload\":{},\"labelIsSrOnly\":true,\"searchInputLabel\":\"Sök användare\",\"searchInputPlaceholder\":\"Sök användare...\",\"canSearch\":true,\"emptySearchResult\":false,\"isSearching\":false,\"isSearchType\":true,\"isFileType\":false,\"searchTotalCount\":0,\"searchResultTotalCountOnFetch\":0,\"extraMessageIsEnabled\":false,\"canBrowse\":false,\"automaticSelectionOfFirstEntry\":true,\"limitSearchResultCount\":150,\"limitSearchResult\":false,\"limitedSearchResult\":[],\"isResultLimitReached\":false,\"selectedItems\":[],\"hasSelectedItem\":false,\"selectedItem\":null,\"emptyReporter\":{},\"searchReporter\":{},\"browseMore\":{\"_settings\":{\"canClose\":false,\"oneMessageOnly\":false,\"validate\":false,\"alwaysUseExecuteData\":false,\"addVerification\":false},\"_verificationDeferred\":{},\"isVerificationVisible\":false,\"canExecute\":false,\"canExecuteVerification\":true,\"isExecuting\":false}}},{\"title\":\"Grupp\",\"viewModel\":{\"messageTracker\":{\"_settings\":{\"canClose\":true,\"oneMessageOnly\":true,\"validate\":false,\"alwaysUseExecuteData\":false,\"addVerification\":false},\"canClose\":true,\"currentErrors\":[],\"warnings\":[],\"success\":[],\"hasErrors\":false,\"hasWarnings\":false,\"hasSuccess\":false,\"hasAny\":false},\"canClose\":true,\"currentErrors\":[],\"success\":[],\"hasErrors\":false,\"warnings\":[],\"hasWarnings\":false,\"hasSuccess\":false,\"settings\":{\"canClose\":false,\"oneMessageOnly\":false,\"validate\":false,\"alwaysUseExecuteData\":false,\"addVerification\":false},\"pagination\":{\"pagingTake\":15,\"currentIndex\":0},\"hasLargeTag\":false,\"searchTypes\":[],\"selectedSearchType\":null,\"modules\":[],\"acceptedFiles\":[],\"hasFocus\":false,\"searchResult\":[],\"searchInputText\":\"\",\"fileToUpload\":{},\"labelIsSrOnly\":true,\"searchInputLabel\":\"Sök grupper...\",\"searchInputPlaceholder\":\"Sök grupper...\",\"canSearch\":true,\"emptySearchResult\":false,\"isSearching\":false,\"isSearchType\":true,\"isFileType\":false,\"searchTotalCount\":0,\"searchResultTotalCountOnFetch\":0,\"extraMessageIsEnabled\":false,\"canBrowse\":false,\"automaticSelectionOfFirstEntry\":true,\"limitSearchResultCount\":150,\"limitSearchResult\":false,\"limitedSearchResult\":[],\"isResultLimitReached\":false,\"selectedItems\":[],\"hasSelectedItem\":false,\"selectedItem\":null,\"emptyReporter\":{},\"searchReporter\":{},\"browseMore\":{\"_settings\":{\"canClose\":false,\"oneMessageOnly\":false,\"validate\":false,\"alwaysUseExecuteData\":false,\"addVerification\":false},\"_verificationDeferred\":{},\"isVerificationVisible\":false,\"canExecute\":false,\"canExecuteVerification\":true,\"isExecuting\":false}}}],\"searchViewModel\":{\"title\":null,\"viewModel\":null},\"hasFocus\":false,\"searchViewModelTracker\":{\"modes\":[{\"isActive\":true,\"label\":\"Användare\",\"isVisible\":true,\"isDisabled\":false},{\"isActive\":false,\"label\":\"Grupp\",\"isVisible\":true,\"isDisabled\":false}],\"selectedMode\":{\"isActive\":true,\"label\":\"Användare\",\"isVisible\":true,\"isDisabled\":false},\"hasSelectedMode\":true},\"currentSelectedItems\":[],\"selectedItems\":[],\"selectedItem\":null,\"hasSelectedItem\":false,\"itemsToAdd\":[],\"itemsToRemove\":[],\"addOn\":null,\"hasAddon\":false,\"placeholder\":\"Ingen hanterad av är vald...\",\"canSelect\":true,\"canClearSelection\":true,\"remove\":{\"_settings\":{\"canClose\":false,\"oneMessageOnly\":false,\"validate\":false,\"alwaysUseExecuteData\":false,\"addVerification\":false},\"_verificationDeferred\":{},\"isVerificationVisible\":false,\"canExecute\":true,\"canExecuteVerification\":true,\"isExecuting\":false},\"select\":{\"_settings\":{\"canClose\":false,\"oneMessageOnly\":false,\"validate\":false,\"alwaysUseExecuteData\":false,\"addVerification\":true},\"_verificationDeferred\":{},\"isVerificationVisible\":false,\"canExecute\":true,\"canExecuteVerification\":false,\"isExecuting\":false},\"searchResult\":[]}");
            this.isBatch = false;
            this.id = idLookup.result[0].id;
            this.name = idLookup.result[0].name;
            this.isNew = false;
            this.clientId = idLookup.result[0].id;
            this.validClients = new List<object>();
            this.description = pcLookup.description;
            this.mac = pcLookup.macAddress;
            this.uuid = pcLookup.uuid;
            this.serial = pcLookup.serialNumber;
            if (serial == null)
            {
                this.serial = infoLookup.serial;
            }
            this.hardwareModelId = pcLookup.hardwareModelId;
            this.canPickDeploymentTemplate = true;
            this.hadHardwareModelIdOnCreation = true;
            this.hasHardwareModelId = true;
            this.operatingSystemId = 43; //Kommer behöva ändra denna när Sysman byter till något nytt
            this.oldOperatingSystemId = pcLookup.operatingSystemId;
            this.canChangeOperatingSystem = true;
            this.hasBeenDeployedBefore = true;
            if (installationType)
            {
                this.installationType = "0";
            }
            else
            {
                this.installationType = "1";
            }
            this.canChangeInstallationType = true;
            this.deploymentTemplateToUse = RoleToDeployement(infoLookup);
            this.previouslyUsedDeploymentTemplate = pcLookup.deployment.deploymentTemplateId;
            this.hasDeploymentTemplate = true;
            this.userSelectedCleanupDependentResources = false;
            this.canCleanupDependentResources = true;
            this.userSelectedUseWakeOnLan = false;
            this.canUseWakeOnLan = false;
            this.useWakeOnLan = false;
            this.roles = new List<int>();
            foreach (Role role in pcLookup.roles)
            {
                this.roles.Add(role.id);
            }
            this.executeDate = "";
            this.primaryUsers = pcLookup.primaryUsers;
            this.primaryUsersFull = null;
            this.primaryUsersToAdd = null;
            this.primaryUsersToRemove = null;
            this.hasChangedManagedBy = false;
            this.isUpgrade = false;
        }
        private Regex oldRoleRx = new Regex(@"[A-Z][a-z]{2}_Wrk_PR");
        private Regex newRoleRx = new Regex(@"Sll_Wrk_[A-Z][a-z]{2}_PR");
        public int RoleToDeployement(InfoLookup infoLookup)
        {
            string role;
            bool isLaptop;
            if (infoLookup.clientName.Substring(3,1).ToUpper()=="D")
            {
                isLaptop = false;
            }
            else if (infoLookup.clientName.Substring(3, 1).ToUpper() == "L")
            {
                isLaptop = true;
            }
            else { return -1; }
            if (infoLookup.collections.Where(r => oldRoleRx.IsMatch(r)).ToList().Count() > 0)
            {
                role = infoLookup.collections.Where(r => oldRoleRx.IsMatch(r)).ToList().First().Substring(11);
            }
            else if (infoLookup.installedApplications.Where(r => newRoleRx.IsMatch(r.name)).ToList().Count() > 0)
            {
                role = infoLookup.installedApplications.Where(r => newRoleRx.IsMatch(r.name)).ToList().First().name.Substring(15);
            }
            else
            {
                role = "Okänd";
            }
            if (role == "Okänd" || role == "Kiosk_PC")
            {
                if (infoLookup.collections.Where(f => f.StartsWith("Gai_App_CitrixReceiverVardTerminal")).ToList().Count() > 0 || infoLookup.installedApplications.Where(r => r.name == "Kar_Rol_Vardterminal-Kiosk").ToList().Count() > 0)
                {
                    role = "Vårdterminal";
                }
            }
            if (isLaptop)
            {
                switch (role)
                {
                    case "Administrativ_PC":
                    case "Tekniker_PC":
                    case "Administrativ_PC_64bit":
                        return 496;
                    case "Flodes_PC":
                    case "Undantag_PC":
                    case "Konferens_PC":
                    case "Lakemedelsvagn_PC":
                    case "Utbildnings_PC":
                    case "QA":
                    case "DX":
                        return -1;
                    case "Sakerhets_PC":
                        return 506;
                    case "Vard_PC":
                    case "VardPC_bild":
                        return 513;
                    case "Vårdterminal":
                        return 516;
                    case "Vardterminal":
                        return 516;
                    case "Kiosk_PC":
                        return 498;
                    case "MTWM_PC":
                        return 494;
                    case "MTM_PC":
                        return 501;
                    default:
                        return -1;
                }
            }
            else if (!isLaptop)
            {
                switch (role)
                {
                    case "Administrativ_PC":
                    case "Tekniker_PC":
                    case "Administrativ_PC_64bit":
                        return 495;
                    case "Flodes_PC":
                    case "Undantag_PC":
                    case "Konferens_PC":
                    case "Lakemedelsvagn_PC":
                    case "Utbildnings_PC":
                    case "QA":
                    case "DX":
                        return -1;
                    case "Sakerhets_PC":
                        return 505;
                    case "Vard_PC":
                    case "VardPC_bild":
                        return 512;
                    case "Vardterminal":
                        return 516;
                    case "Vårdterminal":
                        return 516;
                    case "Kiosk_PC":
                        return 498;
                    case "MTWM_PC":
                        return 494;
                    case "MTM_PC":
                        return 501;
                    default:
                        return -1;
                }
            }
            else
            {
                return -1;
            }
        }
        public ToolResponse GetReadableDeployement()
        {
            string tempString;
            switch (deploymentTemplateToUse)
            {
                case 496:
                    tempString = $"\"SLL - Administrativ PC (Laptop)\"";
                    break;
                case 506:
                    tempString = $"\"SLL - Säkerhets PC (Laptop)\"";
                    break;
                case 513:
                    tempString = $"\"SLL - Vård PC (Laptop)\"";
                    break;
                case 516:
                    tempString = $"\"Vårdterminal PC\"";
                    break;
                case 498:
                    tempString = $"\"SLL - Kiosk PC (Kiosk)\"";
                    break;
                case 494:
                    tempString = $"\"SLL - MTWM PC (MTP)\"";
                    break;
                case 501:
                    tempString = $"\"SLL - MTM PC (MTP)\"";
                    break;
                case 495:
                    tempString = $"\"SLL - Administrativ PC (Desktop)\"";
                    break;
                case 505:
                    tempString = $"\"SLL - Säkerhets PC (Desktop)\"";
                    break;
                case 512:
                    tempString = $"\"SLL - Vård PC (Desktop)\"";
                    break;
                case -1:
                default:
                    return new ToolResponse("Felaktig/Okänd roll på datorn, ingen OSD-kollektion utskjuten!");
            }
            return new ToolResponse(tempString + $" har blivit utskjuten på {name}");
        }
        public int id { get; set; }
        public string name { get; set; }
        public bool isNew { get; set; }
        public bool isBatch { get; set; }
        public int clientId { get; set; }
        public List<object> validClients { get; set; }
        public string description { get; set; }
        public string mac { get; set; }
        public string uuid { get; set; }
        public string serial { get; set; }
        public int hardwareModelId { get; set; }
        public bool canPickDeploymentTemplate { get; set; }
        public bool hadHardwareModelIdOnCreation { get; set; }
        public bool hasHardwareModelId { get; set; }
        public int operatingSystemId { get; set; }
        public int oldOperatingSystemId { get; set; }
        public bool canChangeOperatingSystem { get; set; }
        public bool hasBeenDeployedBefore { get; set; }
        public string installationType { get; set; }
        public bool canChangeInstallationType { get; set; }
        public int deploymentTemplateToUse { get; set; }
        public object previouslyUsedDeploymentTemplate { get; set; }
        public bool hasDeploymentTemplate { get; set; }
        public bool userSelectedCleanupDependentResources { get; set; }
        public bool canCleanupDependentResources { get; set; }
        public bool cleanupDependentResources { get; set; }
        public bool userSelectedUseWakeOnLan { get; set; }
        public bool canUseWakeOnLan { get; set; }
        public bool useWakeOnLan { get; set; }
        public List<int> roles { get; set; }
        public string executeDate { get; set; }
        public List<object> primaryUsersFull { get; set; }
        public List<object> primaryUsersToAdd { get; set; }
        public List<object> primaryUsersToRemove { get; set; }
        public PrimaryUsersPicker primaryUsersPicker { get; set; }
        public List<object> primaryUsers { get; set; }
        public bool hasChangedManagedBy { get; set; }
        public ManagedByPicker managedByPicker { get; set; }
        public bool isUpgrade { get; set; }
    }


}
